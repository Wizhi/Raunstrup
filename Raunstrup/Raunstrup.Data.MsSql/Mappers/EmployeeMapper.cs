﻿using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Proxies;
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
                command.CommandText = @"SELECT e.EmployeeId, e.Name, es.SkillId
                                        FROM Employee e
                                        LEFT JOIN EmployeeSkill es ON es.EmployeeId = e.EmployeeId
                                        WHERE e.EmployeeId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);
                
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
                command.CommandText = @"SELECT e.EmployeeId, e.Name, es.SkillId
                                        FROM Employee e
                                        LEFT JOIN EmployeeSkill es ON es.EmployeeId = e.EmployeeId
                                        ORDER BY e.EmployeeId";

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

                SetParameters(command, employee);

                connection.Open();
                command.Prepare();
                
                employee.Id = (int) command.ExecuteScalar();
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            using (var update = connection.CreateCommand())
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = connection.CreateCommand())
            using (var merge = connection.CreateCommand())
            {
                update.CommandText = @"UPDATE Employee SET Name=@name
                                       WHERE DraftId=@id";

                // TODO: Make this re-usable
                var idParam = update.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = employee.Id;
                idParam.DbType = DbType.Int32;

                update.Parameters.Add(idParam);

                SetParameters(update, employee);

                tempCreate.CommandText = @"CREATE TABLE #TempEmployeeSkill (EmployeeId int, SkillId int);";

                tempInsert.CommandText = @"INSERT INTO #TempEmployeeSkill (EmployeeId, SkillId)
                                           VALUES ";

                // Apparently you can't reuse IDbDataParameter instances. That kind of sucks.
                var tempIdParam = tempInsert.CreateParameter();

                tempIdParam.ParameterName = "@tempEmployeeId";
                tempIdParam.Value = employee.Id;
                tempIdParam.DbType = DbType.Int32;

                tempInsert.Parameters.Add(tempIdParam);

                var names = new List<string>();

                for (var i = 0; i < employee.Skills.Count; i++)
                {
                    var tempSkillIdParam = tempInsert.CreateParameter();

                    tempSkillIdParam.ParameterName = "@tempSkillId_" + i;
                    tempSkillIdParam.Value = employee.Skills[i].Id;
                    tempSkillIdParam.DbType = DbType.Int32;

                    tempInsert.Parameters.Add(tempSkillIdParam);

                    names.Add(
                        string.Format("(@tempEmployeeId, {0})",
                            tempSkillIdParam.ParameterName
                        )
                    );
                }

                tempInsert.CommandText += string.Join(", ", names);

                merge.CommandText = @"MERGE INTO EmployeeSkill AS t
                                      USING #TempEmployeeSkill AS s
                                      ON t.SkillId = s.SkillId AND t.EmployeeId = s.EmployeeId
                                      WHEN NOT MATCHED BY TARGET THEN 
                                        INSERT (EmployeeId, SkillId) 
                                        VALUES (s.EmployeeId, s.SkillId)
                                      WHEN NOT MATCHED BY SOURCE THEN DELETE;";

                connection.Open();
                update.Prepare();
                tempInsert.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();

                    // TODO: Make only executing temporary insert if needed cleaner.
                    // More smelly code!
                    if (employee.Skills.Count > 0)
                    {
                        tempInsert.ExecuteNonQuery();
                        merge.ExecuteNonQuery();
                    }
                    
                    transaction.Commit();
                }
            }
        }

        public Employee Map(IDataReader reader)
        {
            Employee employee = null;

            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = (int) reader["EmployeeId"],
                    Name = (string) reader["Name"]
                };

                do
                {
                    if (!(reader["SkillId"] is DBNull))
                    {
                        employee.Skills.Add(new SkillProxy(_context, (int) reader["SkillId"]));
                    }
                }
                while (reader.Read() && (int) reader["EmployeeId"] == employee.Id);
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

        private void SetParameters(IDbCommand command, Employee employee)
        {
            var nameParam = command.CreateParameter();

            nameParam.ParameterName = "@name";
            nameParam.Value = employee.Name;
            nameParam.DbType = DbType.AnsiString;
            nameParam.Size = 100;

            command.Parameters.Add(nameParam);
        }
    }
}
