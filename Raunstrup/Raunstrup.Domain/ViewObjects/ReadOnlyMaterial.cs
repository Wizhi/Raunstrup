namespace Raunstrup.Domain.ViewObjects
{
    class ReadOnlyMaterial : ReadOnlyProduct
    {
        private readonly Material _material;

        public ReadOnlyMaterial(Material material) 
            : base(material)
        {
            _material = material;
        }

        public decimal CostProce { get { return _material.CostPrice; } }
    }
}
