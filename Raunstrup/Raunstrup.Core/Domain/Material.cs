namespace Raunstrup.Core.Domain
{
    public class Material : Product
    {
        public Material(string name)
        {
            this.name = name;
        }
        private double CostPrice;
    }
}
