namespace Raunstrup.Core.Domain
{
    public class Product
    {
        protected string name;

        public Product(string name)
        {
            this.name = name;
        }

        protected Product()
        {
            //This needs to be here for the derived classes
        }

        public string getName()
        {
            return name;
        }
    }
}
