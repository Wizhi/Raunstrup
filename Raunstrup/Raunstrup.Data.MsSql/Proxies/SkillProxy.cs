using System;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Proxies
{
    class SkillProxy : Skill
    {
        private readonly Lazy<Skill> _real;

        public SkillProxy(DataContext context, int id)
        {
            _real = new Lazy<Skill>(() => new SkillMapper(context).Get(id));
        }

        public int Id
        {
            get { return _real.Value.Id; }
            set { _real.Value.Id = value; }
        }

        public string Name
        {
            get { return _real.Value.Name; }
            set { _real.Value.Name = value; }
        }
    }
}
