using System.Collections.Generic;
using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class OrderLinesByDraftQuery : IQuery<IList<OrderLine>>
    {
        private readonly int _id;

        public OrderLinesByDraftQuery(int id)
        {
            _id = id;
        }

        public OrderLinesByDraftQuery(Draft draft)
        {
            _id = draft.Id;
        }

        public IList<OrderLine> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM OrderLine WHERE DraftId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = _id;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                throw new NoNullAllowedException();
            }
        }
    }
}
