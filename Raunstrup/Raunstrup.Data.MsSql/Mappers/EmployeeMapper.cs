using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Query;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class EmployeeMapper
    {
        private static readonly IDictionary<string, FieldInfo> EmployeeFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("EmployeeId") { DbType = DbType.Int32} },
            { "Name", new FieldInfo("Name") { DbType = DbType.AnsiString, Size = 100 } }
        };
        private static readonly IDictionary<string, FieldInfo> SkillRelationFields = new Dictionary<string, FieldInfo>
        {
            { "Employee", new FieldInfo("EmployeeId") { DbType = DbType.Int32} },
            { "Skill", new FieldInfo("SkillId") { DbType = DbType.Int32 } }
        };

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
                command.CommandText = @"SELECT EmployeeId, Name
                                        FROM Employee
                                        WHERE EmployeeId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);
                
                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public IList<Employee> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT EmployeeId, Name
                                        FROM Employee";

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
            using (var employeeInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var skillRelation = new InsertCommandWrapper(connection.CreateCommand()))
            {
                employeeInsert.Target("Employee")
                    .Field(EmployeeFields["Name"])
                    .Values(employee.Name)
                    .Apply();

                employeeInsert.Command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                IDbDataParameter employeeIdParameter;

                skillRelation.Target("EmployeeSkill")
                    .Field(SkillRelationFields["Skill"])
                    .Static(SkillRelationFields["Employee"], "@employeeId", out employeeIdParameter);
                
                foreach (var skill in employee.Skills)
                {
                    skillRelation.Values(skill.Id);
                }

                skillRelation.Apply();
                
                connection.Open();
                employeeInsert.Command.Prepare();

                employeeIdParameter.Value = employee.Id = (int) employeeInsert.Command.ExecuteScalar();

                if (employee.Skills.Count > 0)
                {
                    skillRelation.Command.Prepare();
                    skillRelation.Command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = _context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var merge = connection.CreateCommand())
            {
                update.Target("Employee")
                    .Set(EmployeeFields["Name"], employee.Name)
                    .Parameter(EmployeeFields["Id"], "@id", employee.Id)
                    .Where("EmployeeId = @id")
                    .Apply();
                
                tempCreate.CommandText = @"CREATE TABLE #TempEmployeeSkill (EmployeeId int, SkillId int);";
                
                tempInsert.Target("#TempEmployeeSkill")
                    .Field(SkillRelationFields["Skill"])
                    .Static(SkillRelationFields["Employee"], "@insertId", employee.Id);

                foreach (var skill in employee.Skills)
                {
                    tempInsert.Values(skill.Id);
                }

                tempInsert.Apply();

                merge.CommandText = @"MERGE INTO EmployeeSkill AS t
                                      USING #TempEmployeeSkill AS s
                                      ON t.EmployeeId = @employeeId AND t.SkillId = s.SkillId
                                      WHEN NOT MATCHED BY TARGET THEN
	                                      INSERT (EmployeeId, SkillId)
	                                      VALUES (@employeeId, s.SkillId)
                                      WHEN NOT MATCHED BY SOURCE AND t.EmployeeId = @employeeId THEN DELETE;";

                var mergeIdParameter = merge.CreateParameter();

                mergeIdParameter.ParameterName = "@mergeId";
                mergeIdParameter.Value = employee.Id;
                mergeIdParameter.DbType = DbType.Int32;

                merge.Parameters.Add(mergeIdParameter);

                connection.Open();
                update.Command.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Command.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Command.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.Command.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();
                    
                    if (employee.Skills.Count > 0)
                    {
                        tempInsert.Command.Prepare();
                        tempInsert.Command.ExecuteNonQuery();
                    }

                    merge.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public Employee Map(IDataRecord record)
        {
            var id = (int) record["EmployeeId"];

            return new EmployeeGhost(() => new SkillsByEmployeeQuery(id).Execute(_context))
            {
                Id = id,
                Name = (string) record["Name"]
            };
        }

        public IList<Employee> MapAll(IDataReader reader)
        {
            var employees = new List<Employee>();

            while (reader.Read())
            {
                employees.Add(Map(reader));
            }

            return employees;
        }
    }
}
