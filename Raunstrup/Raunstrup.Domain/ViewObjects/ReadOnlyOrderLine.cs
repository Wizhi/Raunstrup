namespace Raunstrup.Domain.ViewObjects
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
