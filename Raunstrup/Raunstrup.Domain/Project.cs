using System;

namespace Raunstrup.Domain
{
    public class Project
    {
        public readonly Draft Draft;
        // TODO: Consider renaming this to something more related to "beginning a project".
        public readonly DateTime OrderDate;

        private int _id;

        public int Id
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

        public Project(Draft draft/*, DateTime orderDate*/)
        {
            Draft = draft;
            // TODO: Consider whether OrderDate is a dependency?
            //OrderDate = orderDate;
        }
    }
}
