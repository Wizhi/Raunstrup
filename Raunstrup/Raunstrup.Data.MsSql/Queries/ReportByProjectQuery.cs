using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Queries
{
    class ReportByProjectQuery : IQuery<Report>
    {
        private readonly Project _project;

        public ReportByProjectQuery(Project project)
        {
            _project = project;
        }

        public IDataReader Execute(IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Report WHERE ProjectId = @projectId";

                var projectIdParam = command.CreateParameter();

                projectIdParam.ParameterName = "@projectId";
                projectIdParam.Value = _project.Id;
                projectIdParam.DbType = DbType.Int32;

                command.Parameters.Add(projectIdParam);

                connection.Open();

                return command.ExecuteReader();
            }
        }
    }
}
