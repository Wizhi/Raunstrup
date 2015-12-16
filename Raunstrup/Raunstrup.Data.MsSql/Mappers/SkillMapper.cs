using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class SkillMapper : AbstractMapper<Skill>
    {
        private readonly IDictionary<string, FieldInfo> SkillFields = new Dictionary<string, FieldInfo>()
        {
            { "Id", new FieldInfo("SkillId") { DbType = DbType.Int32 } },
            { "Name", new FieldInfo("Name") { DbType = DbType.AnsiString, Size = 100 } }
        }; 

        public SkillMapper(DataContext context) 
            : base(context)
        {
        }

        public override Skill Get(int id)
        {
            using (var connection = Context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT SkillId, Name FROM Skill WHERE SkillId=@id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public override IList<Skill> GetAll()
        {
            using (var connection = Context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT SkillId, Name FROM Skill";
                
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Skill skill)
        {
            using (var connection = Context.CreateConnection())
            using (var insert = connection.CreateCommand() /*new InsertCommandWrapper(connection.CreateCommand())*/)
            {
                //insert.Target("Skill")
                //    .Field(SkillFields["Name"])
                //    .Values(skill.Name)
                //    .Apply();

                insert.CommandText = @"INSERT INTO Skill (Name) VALUES (@name);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SetParameters(insert, skill);

                connection.Open();
                insert.Prepare();

                // TODO: Investigate why, when using the wrapper, a NullReferenceException occurs here.
                skill.Id = (int )insert.ExecuteScalar();
            }
        }

        public void Update(Skill skill)
        {
            using (var connection = Context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            {
                update.Target("Skill")
                    .Set(SkillFields["Name"], skill.Name)
                    .Parameter(SkillFields["Id"], "@id", skill.Id)
                    .Where("SkillId = @id")
                    .Apply();
                //update.CommandText = @"UPDATE Skill SET Name=@name WHERE SkillId=@id";

                //var idParam = update.CreateParameter();

                //idParam.ParameterName = "@id";
                //idParam.Value = skill.Id;
                //idParam.DbType = DbType.Int32;

                //update.Parameters.Add(idParam);

                //SetParameters(update, skill);

                connection.Open();
                update.Command.Prepare();

                update.Command.ExecuteNonQuery();
            }
        }

        public override Skill Map(IDataRecord reader)
        {
            return new Skill
            {
                Id = (int) reader["SkillId"],
                Name = (string) reader["Name"]
            };
        }

        public override IList<Skill> MapAll(IDataReader reader)
        {
            var skills = new List<Skill>();

            while (reader.Read())
            {
                skills.Add(Map(reader));
            }

            return skills;
        }

        private void SetParameters(IDbCommand command, Skill skill)
        {
            var nameParam = command.CreateParameter();

            nameParam.ParameterName = "@name";
            nameParam.Value = skill.Name;
            nameParam.DbType = DbType.AnsiString;
            nameParam.Size = 100;

            command.Parameters.Add(nameParam);
        }
    }
}
