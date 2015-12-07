using System;

namespace Raunstrup.Domain
{
    public class Project
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

        public virtual Draft Draft { get; private set; }
        public virtual Employee ResponsiblEmployee { get; set; }
        // TODO: Consider renaming this to something more related to "beginning a project".
        public virtual DateTime OrderDate { get; set; }

        public Project(Draft draft/*, DateTime orderDate*/)
        {
            Draft = draft;
            // TODO: Consider whether OrderDate is a dependency?
            //OrderDate = orderDate;
        }
    }
}
