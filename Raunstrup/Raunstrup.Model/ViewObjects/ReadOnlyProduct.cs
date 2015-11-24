using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Model.ViewObjects
{
    public class ReadOnlyProduct
    {
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
