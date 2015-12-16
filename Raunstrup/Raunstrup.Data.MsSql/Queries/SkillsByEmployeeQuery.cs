using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Queries
{
    class SkillsByEmployeeQuery : IQuery<Skill>
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

        public IDataReader Execute(IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT s.*
                                        FROM Skill s
                                        JOIN EmployeeSkill es ON es.SkillId = s.SkillId
                                        WHERE es.EmployeeId = @id;";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = _id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                return command.ExecuteReader();
            }
        }
    }
}
