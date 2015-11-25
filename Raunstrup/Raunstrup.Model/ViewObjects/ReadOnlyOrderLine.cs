using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Model.ViewObjects
{
    public class ReadOnlyOrderLine
    {
        private readonly OrderLine _orderLine;

        public ReadOnlyOrderLine(OrderLine orderLine)
        {
            _orderLine = orderLine;
        }

        public ReadOnlyProduct Product
        {
            get { return new ReadOnlyProduct(_orderLine.Product);}
        }

        public decimal UnitPrice
        {
            get { return _orderLine.UnitPrice; }
        }

        public int Quantity
        {
            get { return _orderLine.Quantity; }
        }
    }
}
