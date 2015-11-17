using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Draft
    {
        private List<OrderLine> _orderLines = new List<OrderLine>();

        public List<OrderLine> GetOrderLines()
        {
            return _orderLines;
        }

        public void AddOrderLine(LineItem item, int quantity)
        {
            _orderLines.Add(new OrderLine(item,quantity));
        }
    }
}
