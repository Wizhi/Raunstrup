namespace Raunstrup.Core.Domain
{
    public class Material : LineItem
    {
        public Material(string name)
        {
            this.name = name;
        }
        private double CostPrice;
    }
}
