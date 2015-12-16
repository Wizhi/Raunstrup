using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Queries
{
    class DraftsNotAssociatedWithProjectQuery : IQuery<Draft>
    {
        public IDataReader Execute(IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT d.* FROM Draft d
                                        LEFT JOIN Project p ON d.DraftID = p.DraftID
                                        WHERE p.ProjectId IS NULL;";

                connection.Open();

                return command.ExecuteReader();
            }
        }
    }
}
