namespace Raunstrup.Core.Domain
{
    public class LineItem
    {
        protected string Name;

        public LineItem(string name)
        {
            Name = name;
        }

        protected LineItem()
        {
            //This needs to be here for the derived classes
        }

        public string GetName()
        {
            return Name;
        }
    }
}
