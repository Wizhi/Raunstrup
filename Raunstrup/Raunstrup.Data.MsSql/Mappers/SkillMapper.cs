using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class SkillMapper
    {
        private readonly DataContext _context;

        public SkillMapper(DataContext context)
        {
            _context = context;
        }

        public Skill Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Name FROM Skill WHERE SkillId=@id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return Map(reader);
                }
            }
        }

        public IList<Skill> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, Name FROM Skill";
                
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Skill skill)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Skill (Name) VALUES (@name);
                                        SELECT SCOPE_IDENTITY();";

                SetParameters(command, skill);

                connection.Open();
                command.Prepare();

                skill.Id = (int) command.ExecuteScalar();
            }
        }

        public void Update(Skill skill)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Skill SET Name=@name WHERE SkillId=@id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = skill.Id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                SetParameters(command, skill);

                connection.Open();
                command.Prepare();

                skill.Id = (int)command.ExecuteScalar();
            }
        }

        public Skill Map(IDataReader reader)
        {
            Skill skill = null;

            if (reader.Read())
            {
                skill = new Skill()
                {
                    Id = (int) reader["SkillId"],
                    Name = (string) reader["Name"]
                };
            }

            return skill;
        }

        public IList<Skill> MapAll(IDataReader reader)
        {
            var skills = new List<Skill>();
            Skill skill;

            while ((skill = Map(reader)) != null)
            {
                skills.Add(skill);
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
