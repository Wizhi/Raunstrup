namespace Raunstrup.Model
{
    public class ReportLine
    {
        public Product Item { get; private set; }
        public int Quantity { get; private set; }

        public ReportLine(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public Product GetLineItem()
        {
            return Item;
        }

        public int GetQuantity()
        {
            return Quantity;
        }
    }
}
