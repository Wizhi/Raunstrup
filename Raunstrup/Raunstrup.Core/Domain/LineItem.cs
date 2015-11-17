namespace Raunstrup.Core.Domain
{
    public class LineItem
    {
        protected string name;

        public LineItem(string name)
        {
            this.name = name;
        }

        protected LineItem()
        {
            //This needs to be here for the derived classes
        }

        public string getName()
        {
            return name;
        }
    }
}
