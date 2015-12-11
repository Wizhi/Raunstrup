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

        public override int Id
        {
            get { return _real.Value.Id; }
        }

        public override string Name
        {
            get { return _real.Value.Name; }
        }
    }
}
