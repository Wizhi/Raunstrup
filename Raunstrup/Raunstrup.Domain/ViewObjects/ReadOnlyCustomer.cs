namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyCustomer
    {
        private readonly Customer _customer;

        public ReadOnlyCustomer(Customer customer)
        {
            _customer = customer;
        }

        public string Name { get { return _customer.Name; } }

        public string StreetName { get { return _customer.StreetName; } }

        public string StreetNumber { get { return _customer.StreetNumber; } }

        public string City { get { return _customer.City; }}

        public string PostalCode { get { return _customer.PostalCode; } }

        public int Id { get { return _customer.Id; } }
    }
}
