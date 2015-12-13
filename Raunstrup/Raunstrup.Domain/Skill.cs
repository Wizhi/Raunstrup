using System;

namespace Raunstrup.Domain
{
    public class Skill : IEquatable<Skill>
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id != default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

        public virtual string Name { get; set; }

        public bool Equals(Skill other)
        {
            return Id == other.Id;
        }
    }
}
