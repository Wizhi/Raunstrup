using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
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
