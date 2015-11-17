using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Draft
    {
        private List<OrderLine> OrderLines = new List<OrderLine>();

        public List<OrderLine> GetOrderLines()
        {
            return OrderLines;
        }

        public void addOrderLine(Product item, int quantity)
        {
            OrderLines.Add(new OrderLine(item,quantity));
        }
    }
}
