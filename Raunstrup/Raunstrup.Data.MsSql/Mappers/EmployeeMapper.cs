using System.Collections.Generic;
using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class EmployeeMapper
    {
        private readonly DataContext _context;

        public EmployeeMapper(DataContext context)
        {
            _context = context;
        }

        public Employee Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                command.CommandText = "SELECT * FROM Employee WHERE EmployeeId = @id";

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return Map(reader);
                }
            }
        }

        public IList<Employee> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT e.EmployeeId, e.Name FROM Employee e";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Employee (Name) 
                                        VALUES (@name);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var nameParam = command.CreateParameter();

                nameParam.ParameterName = "@name";
                nameParam.Value = employee.Name;
                nameParam.DbType = DbType.AnsiString;
                nameParam.Size = 100;

                command.Parameters.Add(nameParam);

                connection.Open();
                command.Prepare();
                
                employee.Id = (int) command.ExecuteScalar();
            }
        }

        public Employee Map(IDataReader reader)
        {
            Employee employee = null;

            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = (int)reader["EmployeeId"],
                    Name = (string)reader["Name"]
                };
            }

            return employee;
        }

        public IList<Employee> MapAll(IDataReader reader)
        {
            var employees = new List<Employee>();
            Employee employee;

            while ((employee = Map(reader)) != null)
            {
                employees.Add(employee);
            }

            return employees;
        }
    }
}
