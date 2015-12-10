namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyProduct
    {
        public static ReadOnlyProduct Create(Material product)
        {
            return new ReadOnlyMaterial(product);
        }

        public static ReadOnlyProduct Create(WorkHour product)
        {
            return new ReadOnlyWorkHour(product);
        }
        
        public static ReadOnlyProduct Create(Transport product)
        {
            return new ReadOnlyTransport(product);
        }

        private readonly Product _product;

        public string Name
        {
            get { return _product.Name; }
        }

        public int ID
        {
            get { return _product.Id; }
        }

        public decimal SalesPrice
        {
            get { return _product.SalesPrice; }
        }

        public ReadOnlyProduct(Product product)
        {
            _product = product;
        }

    }
}
