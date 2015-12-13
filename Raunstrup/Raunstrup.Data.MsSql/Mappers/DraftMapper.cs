using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class DraftMapper
    {
        private static readonly IDictionary<string, FieldInfo> DraftFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("DraftId") { DbType = DbType.Int32} },
            { "Title", new FieldInfo("WorkTitle") { DbType = DbType.AnsiString, Size = 100 } },
            { "Description", new FieldInfo("[Description]") { DbType = DbType.AnsiString, Size = -1 } },
            { "StartDate", new FieldInfo("StartDate") { DbType = DbType.Date } },
            { "EndDate", new FieldInfo("EndDate") { DbType = DbType.Date } },
            { "DiscountPercentage", new FieldInfo("Discount") { DbType = DbType.Double } },
            { "Type", new FieldInfo("IsDynamic") { DbType = DbType.Boolean } },
            { "Customer", new FieldInfo("CustomerId") { DbType = DbType.Int32 } },
            { "Employee", new FieldInfo("ResponsibleEmployeeId") { DbType = DbType.Int32 } }
        };
        private static readonly IDictionary<string, FieldInfo> OrderLineFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("OrderLineId") { DbType = DbType.Int32 } },
            { "Quantity", new FieldInfo("Quantity") { DbType = DbType.Int32 } },
            { "UnitPrice", new FieldInfo("PricePerUnit") { DbType = DbType.Decimal, Precision = 9, Size = 2 } },
            { "Product", new FieldInfo("ProductId") { DbType = DbType.Int32 } },
            { "Draft", new FieldInfo("DraftId") { DbType = DbType.Int32 } }
        };

        private readonly DataContext _context;

        public DraftMapper(DataContext context)
        {
            _context = context;
        }

        public Draft Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                          DraftId, WorkTitle, [Description], Discount, IsDynamic,
                                          StartDate, EndDate, CustomerId, ResponsibleEmployeeId
                                        FROM Draft
                                        WHERE DraftId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public IList<Draft> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                          DraftId, WorkTitle, [Description], Discount, IsDynamic,
                                          StartDate, EndDate, CustomerId, ResponsibleEmployeeId
                                        FROM Draft";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Draft draft)
        {
            using (var connection = _context.CreateConnection())
            using (var draftInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var orderLinesInsert = new InsertCommandWrapper(connection.CreateCommand()))
            {
                draftInsert
                    .Target("Draft")
                    .Field(DraftFields["Title"])
                    .Field(DraftFields["Description"])
                    .Field(DraftFields["StartDate"])
                    .Field(DraftFields["EndDate"])
                    .Field(DraftFields["DiscountPercentage"])
                    .Field(DraftFields["Type"])
                    .Field(DraftFields["Customer"])
                    .Field(DraftFields["Employee"])
                    .Values(
                        draft.Title, draft.Description,
                        draft.StartDate, draft.EndDate,
                        draft.Type == Draft.DraftType.Dynamic,
                        draft.DiscountPercentage, draft.Customer.Id,
                        draft.ResponsiblEmployee.Id
                    )
                    .Apply();

                draftInsert.Command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                IDbDataParameter draftIdParameter;

                orderLinesInsert
                    .Target("OrderLine")
                    .Field(OrderLineFields["Quantity"])
                    .Field(OrderLineFields["UnitPrice"])
                    .Field(OrderLineFields["Product"])
                    .Static(OrderLineFields["Draft"], "@draftId", out draftIdParameter);
                
                foreach (var orderLine in draft.OrderLines)
                {
                    orderLinesInsert.Values(orderLine.Quantity, orderLine.UnitPrice, orderLine.Product.Id);
                }
                
                connection.Open();
                draftInsert.Command.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    draftInsert.Command.Transaction = transaction;
                    orderLinesInsert.Command.Transaction = transaction;

                    var draftId = (int) draftInsert.Command.ExecuteScalar();

                    if (draft.OrderLines.Count > 0)
                    {
                        draftIdParameter.Value = draftId;
                        orderLinesInsert.Apply().Command.Prepare();
                        orderLinesInsert.Command.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    draft.Id = draftId;
                }
            }
        }

        public void Update(Draft draft)
        {
            using (var connection = _context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var merge = connection.CreateCommand())
            {
                update
                    .Target("Draft")
                    .Set(DraftFields["Title"], draft.Title)
                    .Set(DraftFields["Description"], draft.Description)
                    .Set(DraftFields["StartDate"], draft.StartDate)
                    .Set(DraftFields["EndDate"], draft.EndDate)
                    .Set(DraftFields["DiscountPercentage"], draft.DiscountPercentage)
                    .Set(DraftFields["Type"], draft.Type == Draft.DraftType.Dynamic)
                    .Set(DraftFields["Customer"], draft.Customer.Id)
                    .Parameter(DraftFields["Id"], "@updateId", draft.Id)
                    .Where("DraftId = @updateId")
                    .Apply();
                
                tempCreate.CommandText = @"CREATE TABLE #TempOrderLine
                                           (OrderLineId int, Quantity int, PricePerUnit decimal(9, 2), DraftId int, ProductId int);";
                
                tempInsert
                    .Target("#TempOrderLine")
                    .Field(OrderLineFields["Id"])
                    .Field(OrderLineFields["Quantity"])
                    .Field(OrderLineFields["UnitPrice"])
                    .Field(OrderLineFields["Product"])
                    .Static(OrderLineFields["Draft"], "@insertId", draft.Id);

                foreach (var orderLine in draft.OrderLines)
                {
                    tempInsert.Values(
                        orderLine.Id, orderLine.Quantity,
                        orderLine.UnitPrice, orderLine.Product.Id
                    );
                }

                tempInsert.Apply();

                merge.CommandText = @"MERGE INTO OrderLine AS t
                                      USING #TempOrderLine AS s
                                      ON t.OrderLineId = s.OrderLineId
                                      WHEN MATCHED THEN 
                                        UPDATE SET Quantity=s.Quantity, PricePerUnit=s.PricePerUnit
                                      WHEN NOT MATCHED BY TARGET THEN 
                                        INSERT (Quantity, PricePerUnit, ProductId, DraftId) 
                                        VALUES (s.Quantity, s.PricePerUnit, s.ProductId, @mergeId)
                                      WHEN NOT MATCHED BY SOURCE AND t.DraftId = @mergeId THEN DELETE;";

                var mergeIdParameter = OrderLineFields["Draft"].ToParameter(merge.CreateParameter);

                mergeIdParameter.ParameterName = "@mergeId";
                mergeIdParameter.Value = draft.Id;

                merge.Parameters.Add(mergeIdParameter);

                connection.Open();
                update.Command.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Command.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Command.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.Command.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();

                    if (draft.OrderLines.Count > 0)
                    {
                        tempInsert.Command.Prepare();
                        tempInsert.Command.ExecuteNonQuery();
                    }

                    merge.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public Draft Map(IDataRecord reader)
        {
            var id = (int) reader["DraftId"];
            return new DraftGhost(
                new CustomerProxy(_context, (int) reader["CustomerId"]), 
                () => LoadOrderLines(id)
            )
            {
                Id = id,
                Title = (string) reader["WorkTitle"],
                Description = (string) reader["Description"],
                DiscountPercentage = (double) reader["Discount"],
                StartDate = (DateTime) reader["StartDate"],
                EndDate = (DateTime) reader["EndDate"],
                Type = (bool) reader["IsDynamic"] ? Draft.DraftType.Dynamic : Draft.DraftType.Static,
                ResponsiblEmployee = new EmployeeProxy(_context, (int) reader["ResponsibleEmployeeId"])
            };
        }

        public IList<Draft> MapAll(IDataReader reader)
        {
            var drafts = new List<Draft>();
            
            while (reader.Read())
            {
                drafts.Add(Map(reader));
            }

            return drafts;
        }
        
        private IList<OrderLine> LoadOrderLines(int draftId)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT Quantity, PricePerUnit, ProductId 
                                        FROM OrderLine 
                                        WHERE DraftId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = draftId;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return MapOrderLines(reader);
                }
            }
        }

        private IList<OrderLine> MapOrderLines(IDataReader reader)
        {
            var orderLines = new List<OrderLine>();

            while (reader.Read())
            {
                orderLines.Add(new OrderLine(
                    new ProductProxy(_context, (int) reader["ProductId"]), 
                    (int) reader["Quantity"], 
                    (decimal) reader["PricePerUnit"])
                );
            }

            return orderLines;
        }
    }
}
