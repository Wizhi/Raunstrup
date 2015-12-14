using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    /// <summary>
    /// The DraftMapper is responsible for mapping database records to and from <see cref="Draft"/> objects.
    /// </summary>
    class DraftMapper
    {
        /// <summary>
        /// Schema information for <see cref="Draft"/>.
        /// </summary>
        private static readonly IDictionary<string, FieldInfo> DraftFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("DraftId") { DbType = DbType.Int32} },
            { "Title", new FieldInfo("WorkTitle") { DbType = DbType.AnsiString, Size = 100 } },
            { "Description", new FieldInfo("[Description]") { DbType = DbType.AnsiString, Size = -1 } },
            { "CreationDate", new FieldInfo("CreationDate") { DbType = DbType.Date } },
            { "StartDate", new FieldInfo("StartDate") { DbType = DbType.Date } },
            { "EndDate", new FieldInfo("EndDate") { DbType = DbType.Date } },
            { "DiscountPercentage", new FieldInfo("Discount") { DbType = DbType.Double } },
            { "Type", new FieldInfo("IsOffer") { DbType = DbType.Boolean } },
            { "Customer", new FieldInfo("CustomerId") { DbType = DbType.Int32 } },
            { "Employee", new FieldInfo("ResponsibleEmployeeId") { DbType = DbType.Int32 } }
        };
        /// <summary>
        /// Schema information for <see cref="OrderLine"/>.
        /// </summary>
        private static readonly IDictionary<string, FieldInfo> OrderLineFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("OrderLineId") { DbType = DbType.Int32 } },
            { "Quantity", new FieldInfo("Quantity") { DbType = DbType.Int32 } },
            { "UnitPrice", new FieldInfo("PricePerUnit") { DbType = DbType.Decimal, Precision = 9, Size = 2 } },
            { "Product", new FieldInfo("ProductId") { DbType = DbType.Int32 } },
            { "Draft", new FieldInfo("DraftId") { DbType = DbType.Int32 } }
        };

        /// <summary>
        /// The current <see cref="DataContext"/>.
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Creates a <see cref="DraftMapper"/>.
        /// </summary>
        /// <param name="context">The context for the mapper.</param>
        public DraftMapper(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Queries a <see cref="Draft"/> from an id.
        /// </summary>
        /// <param name="id">The id of a a <see cref="Draft"/>.</param>
        /// <returns></returns>
        public Draft Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                          d.DraftId, d.WorkTitle, d.[Description], d.Discount, d.IsOffer,
                                          d.StartDate, d.EndDate, d.CustomerId, d.ResponsibleEmployeeId,
                                          d.CreationDate, p.ProjectId
                                        FROM Draft d
                                        LEFT JOIN Project p ON p.DraftId = d.DraftId
                                        WHERE d.DraftId = @id";
                
                var idParam = DraftFields["Id"].ToParameter(command.CreateParameter);

                idParam.ParameterName = "@id";
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

        /// <summary>
        /// Gets all <see cref="Draft"/>s in storage.
        /// </summary>
        /// <returns></returns>
        public IList<Draft> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT 
                                          d.DraftId, d.WorkTitle, d.[Description], d.Discount, d.IsOffer,
                                          d.StartDate, d.EndDate, d.CustomerId, d.ResponsibleEmployeeId,
                                          d.CreationDate, p.ProjectId
                                        FROM Draft d
                                        LEFT JOIN Project p ON p.DraftId = d.DraftId";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        /// <summary>
        /// Maps a <see cref="Draft"/> to the database.
        /// </summary>
        /// <param name="draft"></param>
        public void Insert(Draft draft)
        {
            using (var connection = _context.CreateConnection())
            using (var draftInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var orderLinesInsert = new InsertCommandWrapper(connection.CreateCommand()))
            {
                draftInsert.Target("Draft")
                    .Field(DraftFields["Title"])
                    .Field(DraftFields["Description"])
                    .Field(DraftFields["CreationDate"])
                    .Field(DraftFields["StartDate"])
                    .Field(DraftFields["EndDate"])
                    .Field(DraftFields["DiscountPercentage"])
                    .Field(DraftFields["Type"])
                    .Field(DraftFields["Customer"])
                    .Field(DraftFields["Employee"])
                    .Values(
                        draft.Title, draft.Description,
                        draft.CreationDate, draft.StartDate, 
                        draft.EndDate, draft.DiscountPercentage,
                        draft.Type == Draft.DraftType.Offer,
                        draft.Customer.Id, draft.ResponsiblEmployee.Id
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

                    var draftId = draftInsert.Command.ExecuteScalar();

                    if (draft.OrderLines.Count > 0)
                    {
                        draftIdParameter.Value = draftId;
                        orderLinesInsert.Apply().Command.Prepare();
                        orderLinesInsert.Command.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    draft.Id = (int) draftId;
                }
            }
        }

        /// <summary>
        /// Updates the database records associated with the <see cref="Draft"/>.
        /// </summary>
        /// <remarks><see cref="Project"/> is not updated. Use the <see cref="ProjectMapper"/>.</remarks>
        /// <param name="draft">The <see cref="Draft"/> to update.</param>
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
                    .Set(DraftFields["Type"], draft.Type == Draft.DraftType.Offer)
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

        /// <summary>
        /// Maps a given database record to a new <see cref="Draft"/>.
        /// </summary>
        /// <param name="record">The <see cref="IDataRecord"/> to map.</param>
        /// <returns></returns>
        public Draft Map(IDataRecord record)
        {
            var id = (int) record["DraftId"];
            return new DraftGhost(
                new CustomerProxy(_context, (int) record["CustomerId"]), 
                (DateTime) record["CreationDate"],
                () => LoadOrderLines(id)
            ) {
                Id = id,
                Title = (string) record["WorkTitle"],
                Description = (string) record["Description"],
                DiscountPercentage = (double) record["Discount"],
                StartDate = (DateTime) record["StartDate"],
                EndDate = (DateTime) record["EndDate"],
                Type = (bool) record["IsOffer"] ? Draft.DraftType.Offer : Draft.DraftType.Estimate,
                ResponsiblEmployee = new EmployeeProxy(_context, (int) record["ResponsibleEmployeeId"]),
                Project = record["ProjectId"] is DBNull ? null : new ProjectProxy(_context, (int) record["ProjectId"])
            };
        }

        /// <summary>
        /// Maps all available <see cref="IDataRecord"/> in the <see cref="IDataReader"/> to new <see cref="Draft"/> instances.
        /// </summary>
        /// <param name="reader">The <see cref="IDataReader"/> used to read from the database.</param>
        /// <returns></returns>
        public IList<Draft> MapAll(IDataReader reader)
        {
            var drafts = new List<Draft>();
            
            while (reader.Read())
            {
                drafts.Add(Map(reader));
            }

            return drafts;
        }
        
        /// <summary>
        /// Loads all <see cref="OrderLine"/> objects associated with the given <see cref="Draft.Id"/>.
        /// </summary>
        /// <param name="draftId">An id of a <see cref="Draft"/>.</param>
        /// <returns></returns>
        private IList<OrderLine> LoadOrderLines(int draftId)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT ol.OrderLineId, ol.DraftId, ol.Quantity, ol.PricePerUnit, ap.*
                                        FROM OrderLine ol
                                        JOIN AllProducts ap ON ap.ProductId = ol.ProductId 
                                        WHERE ol.DraftId = @id;";

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

        /// <summary>
        /// Maps all available database records to new <see cref="OrderLine"/> objects.
        /// </summary>
        /// <param name="reader">The <see cref="IDataReader"/> used to read from the database.</param>
        /// <returns></returns>
        private IList<OrderLine> MapOrderLines(IDataReader reader)
        {
            var orderLines = new List<OrderLine>();

            while (reader.Read())
            {
                Product product = null;

                if (!(reader["MaterialId"] is DBNull))
                {
                    product = new Material() { CostPrice = (decimal)reader["CostPrice"] };
                }
                else if (!(reader["WorkHourId"] is DBNull))
                {
                    product = new WorkHour();
                }
                else if (!(reader["TransportId"] is DBNull))
                {
                    product = new Transport();
                }
                else
                {
                    // TODO: Handle invalid product.
                }

                product.Id = (int) reader["ProductId"];
                product.Name = (string) reader["Name"];
                product.SalesPrice = (decimal) reader["SalesPrice"];

                orderLines.Add(new OrderLine(
                    product,
                    (int) reader["Quantity"],
                    (decimal) reader["PricePerUnit"]
                ) { Id = (int) reader["OrderLineId"] });
            }

            return orderLines;
        }
    }
}
