using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ProductMapper : AbstractMapper<Product>
    {
        private static readonly IDictionary<string, FieldInfo> ProductFields = new Dictionary<string, FieldInfo>()
        {
            { "Id", new FieldInfo("ProductId") { DbType = DbType.Int32 } },
            { "Name", new FieldInfo("Name") { DbType = DbType.AnsiString, Size = 100 } },
            { "SalesPrice", new FieldInfo("SalesPrice") { DbType = DbType.Decimal, Precision = 9, Scale = 2 } }
        }; 
        // TODO: Give each type a mapping dictionary.
        private static readonly IDictionary<string, FieldInfo> SubFields = new Dictionary<string, FieldInfo>()
        {
            { "Material", new FieldInfo("MaterialId") { DbType = DbType.Int32 } },
            { "CostPrice", new FieldInfo("CostPrice") { DbType = DbType.Decimal, Precision = 9, Scale = 2 } },
            { "WorkHour", new FieldInfo("WorkHourId") { DbType = DbType.Int32 } },
            { "Transport", new FieldInfo("TransportId") { DbType = DbType.Int32 } }
        }; 

        public ProductMapper(DataContext context)
            : base(context)
        {
        }

        public override Product Get(int id)
        {
            using (var connection = Context.CreateConnection())
            {
                var command = connection.CreateCommand();
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                command.CommandText = @"SELECT ap.ProductId, ap.Name, ap.SalesPrice, 
                                               ap.MaterialId, ap.CostPrice, ap.WorkHourId, ap.TransportId 
                                        FROM AllProducts ap
                                        WHERE ap.ProductId = @id";

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public override IList<Product> GetAll()
        {
            using (var connection = Context.CreateConnection())
            {
                var command = connection.CreateCommand();
                
                command.CommandText = @"SELECT ap.ProductId, ap.Name, ap.SalesPrice,
                                               ap.MaterialId, ap.CostPrice, ap.WorkHourId, ap.TransportId 
                                        FROM AllProducts ap";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Warning: smelly code ahead.</remarks>
        /// <param name="product"></param>
        public void Insert(Product product)
        {
            using (var connection = Context.CreateConnection())
            using (var productInsert = connection.CreateCommand())
            using (var subTypeInsert = connection.CreateCommand())
            {
                var productInsertWrapped = new InsertCommandWrapper(productInsert);
                var subTypeInsertWrapped = new InsertCommandWrapper(subTypeInsert);

                productInsertWrapped.Target("Product")
                    .Field(ProductFields["Name"])
                    .Field(ProductFields["SalesPrice"])
                    .Values(product.Name, product.SalesPrice)
                    .Apply();

                productInsertWrapped.Command.CommandText += @"SELECT CAST(SCOPE_IDENTITY() AS INT);";
                
                //// Oh dear lord have mercy on me.
                //// TODO: Implement a better way to insert sub-types of Product. The current one stinks.
                //string table;
                //string primaryKeyField;
                //var fields = new List<string>();
                //var names = new List<string>();

                IDbDataParameter productIdParameter;

                if (product is Material)
                {
                    subTypeInsertWrapped.Target("Material")
                        .Field(SubFields["CostPrice"])
                        .Static(SubFields["Material"], "@productId", out productIdParameter)
                        .Values(((Material) product).CostPrice);
                    //table = "Material";
                    //primaryKeyField = "MaterialId";

                    //var costPriceParam = subTypeInsert.CreateParameter();

                    //costPriceParam.ParameterName = "@costPrice";
                    //costPriceParam.Value = ((Material) product).CostPrice;
                    //costPriceParam.DbType = DbType.Decimal;
                    //costPriceParam.Precision = 9;
                    //costPriceParam.Scale = 2;

                    //subTypeInsert.Parameters.Add(costPriceParam);

                    //fields.Add("CostPrice");
                    //names.Add(costPriceParam.ParameterName);
                }
                else if (product is WorkHour)
                {
                    subTypeInsertWrapped.Target("WorkHour")
                        .Static(SubFields["WorkHour"], "@productId", out productIdParameter);
                    //table = "WorkHour";
                    //primaryKeyField = "WorkHourId";
                }
                else if (product is Transport)
                {
                    subTypeInsertWrapped.Target("Transport")
                        .Static(SubFields["Transport"], "@productId", out productIdParameter);
                    //table = "Transport";
                    //primaryKeyField = "TransportId";
                }
                else
                {
                    throw new ArgumentException("How did you even manage to do this?");
                }
                
                //var productIdParam = subTypeInsert.CreateParameter();

                //productIdParam.ParameterName = "@productId";
                //productIdParam.DbType = DbType.Int32;

                //fields.Add(primaryKeyField);
                //names.Add("@productId");

                //subTypeInsert.Parameters.Add(productIdParam);
                //// My eyes are bleeding.
                //subTypeInsert.CommandText = "INSERT INTO " + table + " (" + string.Join(", ", fields) + ") VALUES (" +
                //                            string.Join(", ", names) + ")";

                connection.Open();
                productInsert.Prepare();
                subTypeInsert.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    productInsertWrapped.Command.Transaction = transaction;
                    subTypeInsertWrapped.Command.Transaction = transaction;

                    productIdParameter.Value = productInsertWrapped.Command.ExecuteScalar();
                    subTypeInsertWrapped.Apply();

                    subTypeInsertWrapped.Command.ExecuteNonQuery();
                    transaction.Commit();

                    product.Id = (int) productIdParameter.Value;
                }
            }
        }

        public void Update(Product product)
        {
            using (var connection = Context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            {
                update.Command.CommandText = @"UPDATE Product SET 
                                        Name=@name, SalesPrice=@salesPrice
                                        WHERE ProductId=@id;";

                update.Target("Product")
                    .Set(ProductFields["Name"], product.Name)
                    .Set(ProductFields["SalesPrice"], product.SalesPrice)
                    .Parameter(ProductFields["Id"], "@id", product.Id)
                    .Where("ProductId = @id")
                    .Apply();

                //var idParam = update.CreateParameter();

                //idParam.ParameterName = "@id";
                //idParam.Value = product.Id;
                //idParam.DbType = DbType.Int32;

                //update.Parameters.Add(idParam);

                //SetParameters(update, product);

                connection.Open();
                update.Command.Prepare();

                // We kind of need to wrap this in a transaction, since sub-types may be updated as well.
                using (var transaction = connection.BeginTransaction())
                {
                    update.Command.Transaction = transaction;
                    update.Command.ExecuteNonQuery();

                    // TODO: Implement a better way of handling sub types!
                    // This is just..gross.
                    if (product is Material)
                    {
                        using (var materialUpdate = new UpdateCommandWrapper(connection.CreateCommand()))
                        {
                            materialUpdate.Command.Transaction = transaction;

                            materialUpdate.Target("Material")
                                .Set(SubFields["CostPrice"], ((Material) product).CostPrice)
                                .Parameter(SubFields["Material"], "@materialId", product.Id)
                                .Where("MaterialId = @materialId")
                                .Apply();

                            //materialUpdate.CommandText =
                            //    "UPDATE Material SET CostPrice=@costPrice WHERE MaterialId=@meterialId";

                            //var costPriceParam = materialUpdate.CreateParameter();
                            //var materialIdParam = materialUpdate.CreateParameter();

                            //materialIdParam.ParameterName = "@meterialId";
                            //materialIdParam.Value = product.Id;
                            //materialIdParam.DbType = DbType.Int32;

                            //costPriceParam.ParameterName = "@costPrice";
                            //costPriceParam.Value = ((Material)product).CostPrice;
                            //costPriceParam.DbType = DbType.Decimal;
                            //costPriceParam.Precision = 9;
                            //costPriceParam.Scale = 2;

                            //materialUpdate.Parameters.Add(costPriceParam);
                            //materialUpdate.Parameters.Add(materialIdParam);

                            materialUpdate.Command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public override Product Map(IDataRecord record)
        {
            Product product = null;
            
            if (!(record["MaterialId"] is DBNull))
            {
                product = new Material() { CostPrice = (decimal) record["CostPrice"] };
            }
            else if (!(record["WorkHourId"] is DBNull))
            {
                product = new WorkHour();
            }
            else if (!(record["TransportId"] is DBNull))
            {
                product = new Transport();
            }
            else
            {
                // TODO: Handle invalid product.
            }

            product.Id = (int) record["ProductId"];
            product.Name = (string) record["Name"];
            product.SalesPrice = (decimal) record["SalesPrice"];

            return product;
        }

        public override IList<Product> MapAll(IDataReader reader)
        {
            var products = new List<Product>();

            while (reader.Read())
            {
                products.Add(Map(reader));
            }

            return products;
        }

        private void SetParameters(IDbCommand command, Product product)
        {
            var nameParam = command.CreateParameter();
            var salesPriceParam = command.CreateParameter();

            nameParam.ParameterName = "@name";
            nameParam.Value = product.Name;
            nameParam.DbType = DbType.AnsiString;
            nameParam.Size = 100;

            salesPriceParam.ParameterName = "@salesPrice";
            salesPriceParam.Value = product.SalesPrice;
            salesPriceParam.DbType = DbType.Decimal;
            salesPriceParam.Precision = 9;
            salesPriceParam.Scale = 2;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(salesPriceParam);
        }
    }
}
