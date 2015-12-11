using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class EmployeeGhost : Employee
    {
        private readonly Lazy<IList<Skill>> _skills;

        public EmployeeGhost(Func<IList<Skill>> skills)
        {
            _skills = new Lazy<IList<Skill>>(skills);
        }

        public override IList<Skill> Skills { get { return _skills.Value; } }
    }
}
