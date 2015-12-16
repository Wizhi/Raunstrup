using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class DraftsNotAssociatedWithProjectQuery : IQuery<IList<Draft>>
    {
        public IList<Draft> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT d.* FROM Draft d
                                        LEFT JOIN Project p ON d.DraftID = p.DraftID
                                        WHERE p.ProjectId IS NULL;";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return new DraftMapper(context).MapAll(reader);
                }
            }
        }
    }
}
