using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlySkill
    {
        private readonly Skill _skill;

        public ReadOnlySkill(Skill skill)
        {
            _skill = skill;
        }

        public int Id
        {
            get { return _skill.Id; }
        }

        public string Name
        {
            get { return _skill.Name; }
        }
    }
}
