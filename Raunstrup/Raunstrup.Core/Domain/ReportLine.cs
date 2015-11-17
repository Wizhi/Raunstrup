namespace Raunstrup.Core.Domain
{
    public class ReportLine
    {
        private Product item;
        private int quantity;

        public ReportLine(Product item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
        public Product getLineItem()
        {
            return item;
        }

        public int getQuantity()
        {
            return quantity;
        }
    }
}
