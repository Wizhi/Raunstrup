using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class UncommittedDraftsQuery : IQuery<IList<Draft>>
    {
        public IList<Draft> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Draft d
                                        LEFT JOIN Project p ON d.ID = p.DraftID
                                        WHERE p.ID IS NULL";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return new DraftMapper(context).MapAll(reader);
                }
            }
        }
    }
}
