namespace Raunstrup.Core.Domain
{
    public class OrderLine
    {
        private LineItem _item;
        private int _quantity;
        private double _unitPrice;

        public OrderLine(LineItem item, int quantity)
        {
            _item = item;
            _quantity = quantity;
        }
        public LineItem GetLineItem()
        {
            return _item;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public double GetTotal()
        {
            return _unitPrice * _quantity; 
        }
    }
}
