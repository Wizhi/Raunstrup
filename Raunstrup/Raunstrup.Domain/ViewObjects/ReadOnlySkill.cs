using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain.ViewObjects
{
    class ReadOnlySkill
    {
        private readonly Skill _real;

        public ReadOnlySkill(Skill real)
        {
            _real = real;
        }

        public int Id
        {
            get { return _real.Id; }
        }

        public string Name
        {
            get { return _real.Name; }
        }
    }
}
