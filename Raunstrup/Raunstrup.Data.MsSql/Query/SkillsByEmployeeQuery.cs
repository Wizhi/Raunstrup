using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class SkillsByEmployeeQuery : IQuery<IList<Skill>>
    {
        private readonly int _id;

        public SkillsByEmployeeQuery(int id)
        {
            _id = id;
        }

        public SkillsByEmployeeQuery(Employee employee)
        {
            _id = employee.Id;
        }

        public IList<Skill> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT s.SkillId, s.Name 
                                        FROM Skill s
                                        JOIN EmployeeSkill es ON es.SkillId = s.SkillId
                                        WHERE es.EmployeeId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = _id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return new SkillMapper(context).MapAll(reader);
                }
            }
        }
    }
}
