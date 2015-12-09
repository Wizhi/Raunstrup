using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class ReportByProjectQuery : IQuery<IList<Report>>
    {
        private readonly Project _project;
        private readonly ReportMapper _mapper;

        public ReportByProjectQuery(Project project)
        {
            _project = project;
        }

        public IList<Report> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Project WHERE ProductId = @projectId";

                var projectIdParam = command.CreateParameter();

                projectIdParam.ParameterName = "@projectId";
                projectIdParam.Value = _project.Id;
                projectIdParam.DbType = DbType.Int32;

                command.Parameters.Add(projectIdParam);

                using (var reader = command.ExecuteReader())
                {
                    return new ReportMapper(context).MapAll(reader);
                }
            }
        }
    }
}
