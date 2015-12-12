using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Proxies;
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
            {
                insert.Target("Project")
                    .Field(ProjectFields["OrderDate"])
                    .Field(ProjectFields["Draft"])
                    .Values(project.OrderDate, project.Draft.Id)
                    .Apply();

                insert.Command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                
                connection.Open();
                insert.Command.Prepare();

                project.Id = (int) insert.Command.ExecuteScalar();
            }
        }

        public void Update(Project project)
        {
            using (var connection = _context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            {
                update.Target("Project")
                    .Set(ProjectFields["OrderDate"], project.OrderDate)
                    .Set(ProjectFields["Draft"], project.Draft.Id)
                    .Where("ProjectId = @id")
                    .Apply();

                var idParam = update.Command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = project.Id;
                idParam.DbType = DbType.Int32;

                update.Command.Parameters.Add(idParam);
                
                connection.Open();
                update.Command.Prepare();

                project.Id = (int) update.Command.ExecuteScalar();
            }
        }

        public Project Map(IDataRecord record)
        {
            return new Project(new DraftProxy(_context, (int) record["DraftId"]))
            {
                Id = (int) record["ProjectId"],
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
