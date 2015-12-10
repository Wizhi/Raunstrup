namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyMaterial : ReadOnlyProduct
    {
        private readonly Material _material;

        public ReadOnlyMaterial(Material material) 
            : base(material)
        {
            _material = material;
        }

        public decimal CostPrice { get { return _material.CostPrice; } }
    }
}
