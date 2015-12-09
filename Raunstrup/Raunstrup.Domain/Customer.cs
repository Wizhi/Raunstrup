namespace Raunstrup.Domain
{
    public class Customer
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id != default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

        public virtual string Name { get; set; }

        public virtual string StreetName { get; set; }

        public virtual string StreetNumber { get; set; }

        public virtual string City { get; set; }

        public virtual string PostalCode { get; set; }
    }
}
