using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ProjectMapper
    {
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
                command.CommandText = @"SELECT p.ProjectId, p.OrderDate, p.DraftId, p.ResponsibleEmployeeId 
                                        FROM Project p 
                                        WHERE ProjectId = @id";

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

        public IList<Project> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                          p.ProjectId, p.OrderDate, 
                                          p.DraftId, p.ResponsibleEmployeeId 
                                        FROM Project p 
                                        ORDER BY p.ProjectId";

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
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Project (OrderDate, DraftId, ResponsibleEmployeeId) 
                                        VALUES (@date, @draftId, @employeeId);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
                
                SetParameters(command, project);
                
                connection.Open();
                command.Prepare();
                
                project.Id = (int) command.ExecuteScalar();
            }
        }

        public void Update(Project project)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Project SET
                                        OrderDate=@date, DraftId=@draftId, ResponsibleEmployeeId=@employeeId)
                                        WHERE ProjectId=@id;";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = project.Id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                SetParameters(command, project);

                connection.Open();
                command.Prepare();

                project.Id = (int) command.ExecuteScalar();
            }
        }

        public Project Map(IDataReader reader)
        {
            Project project = null;

            if (reader.Read())
            {
                project = new Project(new DraftProxy(_context, (int) reader["DraftId"]))
                {
                    Id = (int) reader["ProjectId"],
                    OrderDate = (DateTime) reader["OrderDate"],
                    ResponsiblEmployee = new EmployeeProxy(_context, (int) reader["ResponsibleEmployeeId"])
                };
            }

            return project;
        }

        public IList<Project> MapAll(IDataReader reader)
        {
            var projects = new List<Project>();
            Project project;

            while ((project = Map(reader)) != null)
            {
                projects.Add(project);
            }

            return projects;
        }

        private void SetParameters(IDbCommand command, Project project)
        {
            var dateParam = command.CreateParameter();
            var draftParam = command.CreateParameter();
            var employeeParam = command.CreateParameter();

            dateParam.ParameterName = "@date";
            dateParam.Value = project.OrderDate;
            dateParam.DbType = DbType.Date;

            draftParam.ParameterName = "@draftId";
            draftParam.Value = project.Draft.Id;
            draftParam.DbType = DbType.Int32;

            employeeParam.ParameterName = "@employeeId";
            employeeParam.Value = project.ResponsiblEmployee.Id;
            employeeParam.DbType = DbType.Int32;

            command.Parameters.Add(dateParam);
            command.Parameters.Add(draftParam);
            command.Parameters.Add(employeeParam);
        }
    }
}
