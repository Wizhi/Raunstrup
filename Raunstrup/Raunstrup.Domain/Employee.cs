using System;
using System.Collections.Generic;

namespace Raunstrup.Domain
{
    public class Employee : IEquatable<Employee>
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id == default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

        public virtual string Name { get; set; }

        public virtual IList<Skill> Skills { get; private set; }

        public Employee()
        {
            Skills = new List<Skill>();
        }

        public bool Equals(Employee other)
        {
            return Id == other.Id;
        }
    }
}
