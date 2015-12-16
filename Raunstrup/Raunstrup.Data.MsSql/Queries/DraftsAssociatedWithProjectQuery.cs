using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Queries
{
    class DraftsAssociatedWithProjectQuery : IQuery<Draft>
    {
        public IDataReader Execute(IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Draft d
                                        LEFT JOIN Project p ON d.ID = p.DraftID
                                        WHERE p.ProjectId IS NULL";

                connection.Open();

                return command.ExecuteReader();
            }
        }
    }
}
