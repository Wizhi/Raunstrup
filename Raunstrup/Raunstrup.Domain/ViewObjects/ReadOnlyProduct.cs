using System;

namespace Raunstrup.Domain.ViewObjects
{
    abstract public class ReadOnlyProduct
    {
        public static ReadOnlyProduct Create(Product product)
        {
            ReadOnlyProduct read = null;

            if (product is Material)
            {
                read = new ReadOnlyMaterial((Material) product);
            }
            else if (product is WorkHour)
            {
                read = new ReadOnlyWorkHour((WorkHour) product);
            }
            else if (product is Transport)
            {
                read = new ReadOnlyTransport((Transport) product);
            }
            else
            {
                throw new ArgumentException("What in the world did you even pass to me?");
            }

            return read;
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
