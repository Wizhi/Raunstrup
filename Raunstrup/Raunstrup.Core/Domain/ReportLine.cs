namespace Raunstrup.Core.Domain
{
    public class ReportLine
    {
        private LineItem item;
        private int quantity;

        public ReportLine(LineItem item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
        public LineItem getLineItem()
        {
            return item;
        }

        public int getQuantity()
        {
            return quantity;
        }
    }
}
