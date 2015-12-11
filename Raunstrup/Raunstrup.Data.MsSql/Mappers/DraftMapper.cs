using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class DraftMapper
    {
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
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                var fields = new[]
                {
                     "d.DraftId",
                     "d.WorkTitle",
                     "d.[Description]",
                     "d.Discount",
                     "d.StartDate",
                     "d.EndDate",
                     "d.CustomerId",
                     "d.ResponsibleEmployeeId",
                     "ol.OrderLineId",
                     "ol.Quantity",
                     "ol.PricePerUnit",
                     "ol.ProductId"
                };

                var query = new[]
                {
                    "SELECT " + string.Join(",", fields),
                    "FROM Draft d",
                    "JOIN OrderLine ol ON ol.DraftId = d.DraftId",
                    "WHERE d.DraftId = @id"
                };

                command.CommandText = string.Join(" ", query);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return Map(reader);
                }
            }
        }

        public IList<Draft> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                var fields = new[]
                {
                     "d.DraftId",
                     "d.WorkTitle",
                     "d.[Description]",
                     "d.Discount",
                     "d.StartDate",
                     "d.EndDate",
                     "d.CustomerId",
                     "ol.Quantity",
                     "ol.PricePerUnit",
                     "ol.ProductId"
                };

                var query = new[]
                {
                    "SELECT " + string.Join(",", fields),
                    "FROM Draft d",
                    "JOIN OrderLine ol ON ol.DraftId = d.DraftId",
                    "ORDER BY d.DraftId"
                };

                command.CommandText = string.Join(" ", query);

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
            using (var draftInsert = connection.CreateCommand())
            using (var orderLinesInsert = connection.CreateCommand())
            {
                draftInsert.CommandText = @"INSERT INTO Draft 
                                              (WorkTitle, [Description], StartDate, EndDate, Discount, CustomerId, ResponsibleEmployeeId) 
                                            VALUES 
                                              (@title, @description, @startDate, @endDate, @discount, @customerId, @employeeId); 
                                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SetParameters(draftInsert, draft);

                orderLinesInsert.CommandText = "INSERT INTO OrderLine (Quantity, PricePerUnit, ProductId, DraftId) VALUES" +
                                               string.Join(", ", CreateOrderLineParameters(orderLinesInsert, draft));

                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    draftInsert.Transaction = transaction;
                    orderLinesInsert.Transaction = transaction;

                    var draftIdParam = orderLinesInsert.Parameters["@draftId"] as IDbDataParameter;

                    draftIdParam.Value = draftInsert.ExecuteScalar();

                    // Well, we can't insert orderlines that aren't there.
                    // TODO: Find a better way to avoid issuing the INSERT INTO OrderLine query when no orderlines exist.
                    if (draft.OrderLines.Count > 0)
                    {
                        orderLinesInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    draft.Id = (int) draftIdParam.Value;
                }
            }
        }

        public void Update(Draft draft)
        {
            using (var connection = _context.CreateConnection())
            using (var update = connection.CreateCommand())
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = connection.CreateCommand())
            using (var merge = connection.CreateCommand())
            {
                update.CommandText = @"UPDATE Draft SET 
                                         WorkTitle=@title, [Description]=@description, StartDate=@startDate,
                                         EndDate=@endDate, Discount=@discount, CustomerId=@customerId
                                       WHERE DraftId=@draftId";

                // TODO: Make this re-usable
                var idParam = update.CreateParameter();

                idParam.ParameterName = "@draftId";
                idParam.Value = draft.Id;
                idParam.DbType = DbType.Int32;

                update.Parameters.Add(idParam);

                SetParameters(update, draft);

                tempCreate.CommandText = @"CREATE TABLE #TempOrderLine
                                           (OrderLineId int, Quantity int, PricePerUnit decimal(9, 2), DraftId int, ProductId int);";
                
                tempInsert.CommandText = @"INSERT INTO #TempOrderLine (OrderLineId, Quantity, PricePerUnit, ProductId, DraftId)
                                           VALUES ";

                // Apparently you can't reuse IDbDataParameter instances. That kind of sucks.
                var tempIdParam = tempInsert.CreateParameter();

                tempIdParam.ParameterName = "@tempDraftId";
                tempIdParam.Value = draft.Id;
                tempIdParam.DbType = DbType.Int32;

                tempInsert.Parameters.Add(tempIdParam);

                var names = new List<string>();

                for (var i = 0; i < draft.OrderLines.Count; i++)
                {
                    var orderLineIdParam = tempInsert.CreateParameter();
                    var quantityParam = tempInsert.CreateParameter();
                    var unitPriceParam = tempInsert.CreateParameter();
                    var productIdParameter = tempInsert.CreateParameter();

                    orderLineIdParam.ParameterName = "@orderLineId_" + i;
                    orderLineIdParam.Value = draft.OrderLines[i].Id;
                    orderLineIdParam.DbType = DbType.Int32;

                    quantityParam.ParameterName = "@quantity_" + i;
                    quantityParam.Value = draft.OrderLines[i].Quantity;
                    quantityParam.DbType = DbType.Int32;

                    unitPriceParam.ParameterName = "@unitPrice_" + i;
                    unitPriceParam.Value = draft.OrderLines[i].UnitPrice;
                    unitPriceParam.DbType = DbType.Decimal;
                    unitPriceParam.Precision = 9;
                    unitPriceParam.Scale = 2;

                    productIdParameter.ParameterName = "@productId_" + i;
                    productIdParameter.Value = draft.OrderLines[i].Product.Id;
                    productIdParameter.DbType = DbType.Int32;

                    tempInsert.Parameters.Add(orderLineIdParam);
                    tempInsert.Parameters.Add(quantityParam);
                    tempInsert.Parameters.Add(unitPriceParam);
                    tempInsert.Parameters.Add(productIdParameter);

                    names.Add(
                        string.Format("({0}, {1}, {2}, {3}, @tempDraftId)",
                            orderLineIdParam.ParameterName,
                            quantityParam.ParameterName,
                            unitPriceParam.ParameterName,
                            productIdParameter.ParameterName
                        )
                    );
                }

                tempInsert.CommandText += string.Join(", ", names);

                merge.CommandText = @"MERGE INTO OrderLine AS t
                                      USING #TempOrderLine AS s
                                      ON t.OrderLineId = s.OrderLineId
                                      WHEN MATCHED THEN 
                                        UPDATE SET t.Quantity=s.Quantity, t.PricePerUnit=s.PricePerUnit
                                      WHEN NOT MATCHED BY TARGET THEN 
                                        INSERT (Quantity, PricePerUnit, ProductId, DraftId) 
                                        VALUES (s.Quantity, s.PricePerUnit, s.ProductId, s.DraftId)
                                      WHEN NOT MATCHED BY SOURCE THEN DELETE;";

                connection.Open();
                update.Prepare();
                tempInsert.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();

                    // TODO: Make only executing temporary insert if needed cleaner.
                    // More smelly code!
                    if (names.Count > 0)
                    {
                        tempInsert.ExecuteNonQuery();
                    }

                    merge.ExecuteNonQuery();
                    
                    transaction.Commit();
                }
            }
        }

        public Draft Map(IDataReader reader)
        {
            Draft draft = null;

            if (reader.Read())
            {
                Console.WriteLine(reader["CustomerId"]);
                draft = new Draft(new CustomerProxy(_context, (int) reader["CustomerId"]))
                {
                    Id = (int) reader["DraftId"],
                    Title = (string) reader["WorkTitle"],
                    Description = (string) reader["Description"],
                    // TODO: Consider making Discount a float
                    DiscountPercentage = (double) reader["Discount"],
                    StartDate = (DateTime) reader["StartDate"],
                    EndDate = (DateTime) reader["EndDate"],
                    ResponsiblEmployee = new EmployeeProxy(_context, (int) reader["ResponsibleEmployeeId"])
                };

                do
                {
                    draft.OrderLines.Add(new OrderLine(new ProductProxy(_context, (int) reader["ProductId"]), (int) reader["Quantity"])
                    {
                        Id = (int) reader["OrderLineId"],
                        UnitPrice = (decimal) reader["PricePerUnit"]
                    });
                }
                while (reader.Read() && (int) reader["DraftId"] == draft.Id);
            }

            return draft;
        }

        public IList<Draft> MapAll(IDataReader reader)
        {
            var drafts = new List<Draft>();
            Draft draft;

            while ((draft = Map(reader)) != null)
            {
                drafts.Add(draft);
            }

            return drafts;
        }

        private void SetParameters(IDbCommand command, Draft draft)
        {
            var workTitleParam = command.CreateParameter();
            var descriptionParam = command.CreateParameter();
            var startDateParam = command.CreateParameter();
            var endDateParam = command.CreateParameter();
            var discountParam = command.CreateParameter();
            var customerIdParam = command.CreateParameter();
            var responsibleEmployeeIdParam = command.CreateParameter();

            workTitleParam.ParameterName = "@title";
            workTitleParam.Value = draft.Title;
            workTitleParam.DbType = DbType.AnsiString;
            workTitleParam.Size = 100;

            descriptionParam.ParameterName = "@description";
            descriptionParam.Value = draft.Description;
            descriptionParam.DbType = DbType.AnsiString;
            descriptionParam.Size = -1;

            startDateParam.ParameterName = "@startDate";
            startDateParam.Value = draft.StartDate;
            startDateParam.DbType = DbType.Date;

            endDateParam.ParameterName = "@endDate";
            endDateParam.Value = draft.EndDate;
            endDateParam.DbType = DbType.Date;

            discountParam.ParameterName = "@discount";
            discountParam.Value = draft.DiscountPercentage;
            discountParam.DbType = DbType.Double;

            customerIdParam.ParameterName = "@customerId";
            customerIdParam.Value = draft.Customer.Id;
            customerIdParam.DbType = DbType.Int32;

            responsibleEmployeeIdParam.ParameterName = "@employeeId";
            responsibleEmployeeIdParam.Value = draft.ResponsiblEmployee.Id;
            responsibleEmployeeIdParam.DbType = DbType.Int32;
            
            command.Parameters.Add(workTitleParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(startDateParam);
            command.Parameters.Add(endDateParam);
            command.Parameters.Add(discountParam);
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(responsibleEmployeeIdParam);
        }

        private IEnumerable<string> CreateOrderLineParameters(IDbCommand command, Draft draft)
        {
            var idParam = command.CreateParameter();

            idParam.ParameterName = "@draftId";
            idParam.Value = draft.Id;
            idParam.DbType = DbType.Int32;

            command.Parameters.Add(idParam);

            var names = new List<string>();

            for (var i = 0; i < draft.OrderLines.Count; i++)
            {
                var quantityParam = command.CreateParameter();
                var unitPriceParam = command.CreateParameter();
                var productIdParameter = command.CreateParameter();

                quantityParam.ParameterName = "@quantity_" + i;
                quantityParam.Value = draft.OrderLines[i].Quantity;
                quantityParam.DbType = DbType.Int32;

                unitPriceParam.ParameterName = "@unitPrice_" + i;
                unitPriceParam.Value = draft.OrderLines[i].UnitPrice;
                unitPriceParam.DbType = DbType.Decimal;
                unitPriceParam.Precision = 9;
                unitPriceParam.Scale = 2;

                productIdParameter.ParameterName = "@productId_" + i;
                productIdParameter.Value = draft.OrderLines[i].Product.Id;
                productIdParameter.DbType = DbType.Int32;

                command.Parameters.Add(quantityParam);
                command.Parameters.Add(unitPriceParam);
                command.Parameters.Add(productIdParameter);

                names.Add(
                    string.Format("({0}, {1}, {2}, @draftId)",
                        quantityParam.ParameterName,
                        unitPriceParam.ParameterName,
                        productIdParameter.ParameterName
                    )
                );
            }

            return names;
        }
    }
}
