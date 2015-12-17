using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class GhostEmployee : Employee
    {
        private readonly Lazy<IList<Skill>> _skills;

        public GhostEmployee(Func<IList<Skill>> skills)
        {
            _skills = new Lazy<IList<Skill>>(skills);
        }

        public override IList<Skill> Skills { get { return _skills.Value; } }
    }
}
