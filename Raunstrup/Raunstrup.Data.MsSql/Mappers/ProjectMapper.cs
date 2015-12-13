using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Data.MsSql.Query;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ProjectMapper
    {
        private static readonly IDictionary<string, FieldInfo> ProjectFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("ProjectId") { DbType = DbType.Int32 } },
            { "OrderDate", new FieldInfo("OrderDate") { DbType = DbType.Date } },
            { "Draft", new FieldInfo("DraftId") { DbType = DbType.Int32 } }
        };
        private static readonly IDictionary<string, FieldInfo> EmployeeRelationFields = new Dictionary<string, FieldInfo>
        {
            { "Project", new FieldInfo("ProjectId") { DbType = DbType.Int32 } },
            { "Employee", new FieldInfo("EmployeeId") { DbType = DbType.Int32} }
        };

        private readonly DataContext _context;

        public ProjectMapper(DataContext context)
        {
            _context = context;
        }

        public Project Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT ProjectId, OrderDate, DraftId 
                                        FROM Project
                                        WHERE ProjectId = @id;";

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

        public IList<Project> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT ProjectId, OrderDate, DraftId
                                        FROM Project";

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Project project)
        {
            using (var connection = _context.CreateConnection())
            using (var insert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var employeeRelation = new InsertCommandWrapper(connection.CreateCommand()))
            {
                insert.Target("Project")
                    .Field(ProjectFields["OrderDate"])
                    .Field(ProjectFields["Draft"])
                    .Values(project.OrderDate, project.Draft.Id)
                    .Apply();

                insert.Command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";


                IDbDataParameter projectIdParameter;

                employeeRelation
                    .Target("OrderLine")
                    .Field(EmployeeRelationFields["Employee"])
                    .Static(EmployeeRelationFields["Project"], "@projectId", out projectIdParameter);

                foreach (var employee in project.Employees)
                {
                    employeeRelation.Values(employee.Id);
                }

                connection.Open();
                insert.Command.Prepare();

                projectIdParameter.Value = project.Id = (int) insert.Command.ExecuteScalar();

                if (project.Employees.Count > 0)
                {
                    employeeRelation.Apply();
                    employeeRelation.Command.Prepare();
                    employeeRelation.Command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Project project)
        {
            using (var connection = _context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var merge = connection.CreateCommand())
            {
                update.Target("Project")
                    .Set(ProjectFields["OrderDate"], project.OrderDate)
                    .Set(ProjectFields["Draft"], project.Draft.Id)
                    .Parameter(ProjectFields["Id"], "@id", project.Id)
                    .Where("ProjectId = @id")
                    .Apply();

                tempCreate.CommandText = @"CREATE TABLE #TempProjectEmployee (EmployeeId int);";

                tempInsert.Target("#TempProjectEmployee")
                    .Field(EmployeeRelationFields["Employee"]);

                foreach (var employee in project.Employees)
                {
                    tempInsert.Values(employee.Id);
                }

                merge.CommandText = @"MERGE INTO ProjectEmployee AS t
                                     USING #TempProjectEmployee AS s
                                     ON t.ProjectId = @mergeId AND t.EmployeeId = s.EmployeeId
                                     WHEN NOT MATCHED BY TARGET THEN
	                                   INSERT (EmployeeId, ProjectId)
	                                   VALUES (s.EmployeeId, @mergeId)
                                     WHEN NOT MATCHED BY SOURCE AND t.ProjectId = @mergeId THEN DELETE;";

                var mergeIdParameter = merge.CreateParameter();

                mergeIdParameter.ParameterName = "@mergeId";
                mergeIdParameter.Value = project.Id;
                mergeIdParameter.DbType = DbType.Int32;

                merge.Parameters.Add(mergeIdParameter);

                connection.Open();
                update.Command.Prepare();
                merge.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Command.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Command.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.Command.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();

                    if (project.Employees.Count > 0)
                    {
                        tempInsert.Apply();
                        tempInsert.Command.Prepare();
                        tempInsert.Command.ExecuteNonQuery();
                    }

                    merge.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public Project Map(IDataRecord record)
        {
            var id = (int) record["ProjectId"];

            return new GhostProject(
                new DraftProxy(_context, (int) record["DraftId"]),
                () => new EmployeesByProjectQuery(id).Execute(_context)
            ) {
                Id = id,
                OrderDate = (DateTime) record["OrderDate"]
            };
        }

        public IList<Project> MapAll(IDataReader reader)
        {
            var projects = new List<Project>();

            while (reader.Read())
            {
                projects.Add(Map(reader));
            }

            return projects;
        }
    }
}
