namespace Raunstrup.Core.Domain
{
    public class Product
    {
        protected string Name;

        public Product(string name)
        {
            Name = name;
        }

        protected Product()
        {
            //This needs to be here for the derived classes
        }

        public string GetName()
        {
            return Name;
        }
    }
}
