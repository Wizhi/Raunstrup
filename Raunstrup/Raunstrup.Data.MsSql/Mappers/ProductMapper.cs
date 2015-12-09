using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ProductMapper
    {
        private readonly DataContext _context;

        public ProductMapper(DataContext context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            using (var connection = _context.CreateConnection())
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
                    return Map(reader);
                }
            }
        }

        public IList<Product> GetAll()
        {
            using (var connection = _context.CreateConnection())
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
            using (var connection = _context.CreateConnection())
            using (var productInsert = connection.CreateCommand())
            using (var subTypeInsert = connection.CreateCommand())
            {
                productInsert.CommandText = @"INSERT INTO Product (Name, SalesPrice) 
                                              VALUES (@name, @salesPrice);
                                              SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SetParameters(productInsert, product);

                // Oh dear lord have mercy on me.
                // TODO: Implement a better way to insert sub-types of Product. The current one stinks.
                string table;
                string primaryKeyField;
                var fields = new List<string>();
                var names = new List<string>();

                if (product is Material)
                {
                    table = "Material";
                    primaryKeyField = "MaterialId";

                    var costPriceParam = subTypeInsert.CreateParameter();

                    costPriceParam.ParameterName = "@costPrice";
                    costPriceParam.Value = ((Material) product).CostPrice;
                    costPriceParam.DbType = DbType.Decimal;
                    costPriceParam.Precision = 9;
                    costPriceParam.Scale = 2;

                    subTypeInsert.Parameters.Add(costPriceParam);
                    
                    fields.Add("CostPrice");
                    names.Add(costPriceParam.ParameterName);
                }
                else if (product is WorkHour)
                {
                    table = "WorkHour";
                    primaryKeyField = "WorkHourId";
                }
                else if (product is Transport)
                {
                    table = "Transport";
                    primaryKeyField = "TransportId";
                }
                else
                {
                    throw new ArgumentException("How did you even manage to do this?");
                }

                var productIdParam = subTypeInsert.CreateParameter();

                productIdParam.ParameterName = "@productId";
                productIdParam.DbType = DbType.Int32;

                fields.Add(primaryKeyField);
                names.Add("@productId");

                subTypeInsert.Parameters.Add(productIdParam);
                // My eyes are bleeding.
                subTypeInsert.CommandText = "INSERT INTO " + table + " (" + string.Join(", ", fields) + ") VALUES (" +
                                            string.Join(", ", names) + ")";

                connection.Open();
                productInsert.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    productInsert.Transaction = transaction;
                    subTypeInsert.Transaction = transaction;

                    productIdParam.Value = productInsert.ExecuteScalar();

                    subTypeInsert.Prepare();

                    subTypeInsert.ExecuteNonQuery();
                    transaction.Commit();

                    product.Id = (int) productIdParam.Value;
                }
            }
        }

        public void Update(Product product)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Product SET 
                                        Name=@name, SalesPrice=@salesPrice
                                        WHERE ProductId=@id;";
                
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@costPrice";
                idParam.Value = ((Material)product).CostPrice;
                idParam.DbType = DbType.Decimal;

                command.Parameters.Add(idParam);

                SetParameters(command, product);
                
                connection.Open();
                command.Prepare();

                // We kind of need to wrap this in a transaction, since sub-types may be updated as well.
                using (var transaction = connection.BeginTransaction())
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();

                    // TODO: Implement a better way of handling sub types!
                    // This is just..gross.
                    if (product is Material)
                    {
                        using (var materialCommand = connection.CreateCommand())
                        {
                            materialCommand.Transaction = transaction;
                            materialCommand.CommandText =
                                "UPDATE Material SET CostPrice=@costPrice WHERE MaterialId=@id";

                            var costPriceParam = materialCommand.CreateParameter();

                            costPriceParam.ParameterName = "@costPrice";
                            costPriceParam.Value = ((Material) product).CostPrice;
                            costPriceParam.DbType = DbType.Decimal;
                            costPriceParam.Precision = 9;
                            costPriceParam.Scale = 2;

                            materialCommand.Parameters.Add(costPriceParam);
                            // TODO: Is it even safe to add a parameter created by another command?
                            materialCommand.Parameters.Add(idParam);

                            materialCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public Product Map(IDataReader reader)
        {
            Product product = null;

            if (reader.Read())
            {
                if (!(reader["MaterialId"] is DBNull))
                {
                    product = new Material() { CostPrice = (decimal) reader["CostPrice"] };
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
            }

            return product;
        }

        public IList<Product> MapAll(IDataReader reader)
        {
            var products = new List<Product>();
            Product product;

            while ((product = Map(reader)) != null)
            {
                products.Add(product);
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
