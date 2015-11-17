namespace Raunstrup.Core.Domain
{
    public class ReportLine
    {
        private Product _item;
        private int _quantity;

        public ReportLine(Product item, int quantity)
        {
            _item = item;
            _quantity = quantity;
        }
        public Product GetLineItem()
        {
            return _item;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }
}
