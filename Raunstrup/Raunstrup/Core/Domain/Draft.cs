using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
{
    public class Draft
    {
        private List<OrderLine> OrderLines = new List<OrderLine>();

        public List<OrderLine> GetOrderLines()
        {
            return OrderLines;
        }

        public void addOrderLine(LineItem item, int quantity)
        {
            OrderLines.Add(new OrderLine(item,quantity));
        }
    }
}
