using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class CustomerMapper
    {
        private readonly DataContext _context;
        private readonly IDictionary<string, FieldInfo> _fields = new Dictionary<string, FieldInfo>
        {
            { "Name", new FieldInfo("Name") { DbType = DbType.AnsiString, Size = 100 } },
            { "City", new FieldInfo("City") { DbType = DbType.AnsiString, Size = 50 } },
            { "PostalCode", new FieldInfo("PostalCode") { DbType = DbType.AnsiString, Size = 4 } },
            { "StreetName", new FieldInfo("StreetName") { DbType = DbType.AnsiString, Size = 50 } },
            { "StreetNumber", new FieldInfo("StreetNumber") { DbType = DbType.AnsiString, Size = 5 } }
        };
        
        public CustomerMapper(DataContext context)
        {
            _context = context;
        }
        
        public Customer Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT CustomerId, Name, StreetName, StreetNumber, City, PostalCode 
                                        FROM Customer 
                                        WHERE CustomerId = @id";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
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
                var wrapped = new InsertCommandWrapper(command);

                wrapped
                    .Target("Customer")
                    .Field(_fields["Name"])
                    .Field(_fields["City"])
                    .Field(_fields["PostalCode"])
                    .Field(_fields["StreetName"])
                    .Field(_fields["StreetNumber"])
                    .Values(
                        customer.Name, customer.City,
                        customer.PostalCode, customer.StreetName,
                        customer.StreetNumber
                    )
                    .Apply();
                
                command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                
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
                var wrapped = new UpdateCommandWrapper(command);

                wrapped
                    .Target("Customer")
                    .Set(_fields["Name"], customer.Name)
                    .Set(_fields["City"], customer.City)
                    .Set(_fields["PostalCode"], customer.PostalCode)
                    .Set(_fields["StreetName"], customer.StreetName)
                    .Set(_fields["StreetNumber"], customer.StreetNumber)
                    .Where("CustomerId = @id")
                    .Apply();

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = customer.Id;

                command.Parameters.Add(idParam);
                
                connection.Open();
                command.Prepare();

                command.ExecuteNonQuery();
            }
        }

        public Customer Map(IDataRecord record)
        {
            return new Customer()
            {
                Id = (int) record["CustomerId"],
                Name = (string) record["Name"],
                City = (string) record["City"],
                PostalCode = (string) record["PostalCode"],
                StreetName = (string) record["StreetName"],
                StreetNumber = (string) record["StreetNumber"]
            };
        }

        public IList<Customer> MapAll(IDataReader reader)
        {
            var customers = new List<Customer>();

            while (reader.Read())
            {
                customers.Add(Map(reader));
            }

            return customers;
        }
    }
}
