using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Queries
{
    class EmployeesByProjectQuery : IQuery<Employee>
    {
        private readonly int _id;

        public EmployeesByProjectQuery(int id)
        {
            _id = id;
        }

        public EmployeesByProjectQuery(Employee employee)
        {
            _id = employee.Id;
        }

        public IDataReader Execute(IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT e.EmployeeId, e.Name 
                                        FROM Employee e
                                        JOIN ProjectEmployee pe ON pe.EmployeeId = e.EmployeeId
                                        WHERE pe.ProjectId = @id";

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
