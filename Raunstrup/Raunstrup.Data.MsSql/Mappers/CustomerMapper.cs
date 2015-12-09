using System.Collections.Generic;
using System.Data;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class CustomerMapper
    {
        private readonly DataContext _context;

        public CustomerMapper(DataContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                command.CommandText = @"SELECT CustomerId, Name, StreetName, StreetNumber, City, PostalCode 
                                        FROM Customer 
                                        WHERE CustomerId = @id";

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return Map(reader);
                }
            }
        }

        public IList<Customer> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT CustomerId, Name, StreetName, StreetNumber, City, PostalCode 
                                        FROM Customer";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Customer customer)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Customer (Name, StreetNumber, StreetName, City, PostalCode) 
                                        VALUES (@name, @streetNumber, @streetName, @city, @postalCode);
                                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SetParameters(command, customer);

                connection.Open();
                command.Prepare();

                customer.Id = (int) command.ExecuteScalar();
            }
        }

        public void Update(Customer customer)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Customer SET
                                        Name=@name, StreetNumber=@streetNumber, StreetName=@streetName, 
                                        City=@city, PostalCode=@postalCode
                                        WHERE CustomerId=@id;";


                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = customer.Id;

                command.Parameters.Add(idParam);

                SetParameters(command, customer);

                connection.Open();
                command.Prepare();

                command.ExecuteNonQuery();
            }
        }

        public Customer Map(IDataReader reader)
        {
            Customer customer = null;

            if (reader.Read())
            {
                customer = new Customer()
                {
                    Id = (int) reader["CustomerId"],
                    Name = (string) reader["Name"],
                    City = (string) reader["City"],
                    PostalCode = (string) reader["PostalCode"],
                    StreetName = (string) reader["StreetName"],
                    StreetNumber = (string) reader["StreetNumber"]
                };
            }

            return customer;
        }

        public IList<Customer> MapAll(IDataReader reader)
        {
            var customers = new List<Customer>();
            Customer customer;

            while ((customer = Map(reader)) != null)
            {
                customers.Add(customer);
            }

            return customers;
        }

        private void SetParameters(IDbCommand command, Customer customer)
        {
            var nameParam = command.CreateParameter();
            var streetNumberParam = command.CreateParameter();
            var streetNameParam = command.CreateParameter();
            var cityParam = command.CreateParameter();
            var postalCodeParam = command.CreateParameter();

            nameParam.ParameterName = "@name";
            nameParam.Value = customer.Name;
            nameParam.DbType = DbType.AnsiString;
            nameParam.Size = 100;

            streetNumberParam.ParameterName = "@streetNumber";
            streetNumberParam.Value = customer.StreetNumber;
            streetNumberParam.DbType = DbType.AnsiString;
            streetNumberParam.Size = 5;

            streetNameParam.ParameterName = "@streetName";
            streetNameParam.Value = customer.StreetName;
            streetNameParam.DbType = DbType.AnsiString;
            streetNameParam.Size = 50;

            cityParam.ParameterName = "@city";
            cityParam.Value = customer.City;
            cityParam.DbType = DbType.AnsiString;
            cityParam.Size = 50;

            postalCodeParam.ParameterName = "@postalCode";
            postalCodeParam.Value = customer.PostalCode;
            postalCodeParam.DbType = DbType.AnsiString;
            postalCodeParam.Size = 4;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(streetNumberParam);
            command.Parameters.Add(streetNameParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(postalCodeParam);
        }
    }
}
