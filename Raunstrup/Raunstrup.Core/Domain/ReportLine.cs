namespace Raunstrup.Core.Domain
{
    public class ReportLine
    {
        private LineItem _item;
        private int _quantity;

        public ReportLine(LineItem item, int quantity)
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
    }
}
