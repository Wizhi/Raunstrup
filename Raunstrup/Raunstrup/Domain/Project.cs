using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
{
    public class Project
    {
        private Draft draft;

        public Project(Draft draft)
        {
            this.draft = draft;
        }

        public Draft GetDraft()
        {
            return draft;
        }
    }
}
