namespace Raunstrup.Core.Domain
{
    public class Material : LineItem
    {
        public Material(string name)
        {
            Name = name;
        }
        private double _costPrice;
    }
}
