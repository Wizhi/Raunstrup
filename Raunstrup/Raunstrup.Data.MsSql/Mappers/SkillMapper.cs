using System;
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
    }
}
