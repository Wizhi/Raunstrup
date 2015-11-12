using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
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
