﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Core.Domain
{
    public class ReadOnlyDraft
    {
        private readonly Draft _draft;

        public string Title
        {
            get { return _draft.Title; }
        }

        public string Description
        {
            get { return _draft.Description; }
        }

        public DateTime StartDate
        {
            get { return _draft.StartDate; }
        }

        public DateTime EndDate
        {
            get { return _draft.EndDate; }
        }

        public DateTime CreationDate
        {
            get { return _draft.CreationDate; }
        }

        public int Id
        {
            get { return _draft.Id; }
        }

        public ReadOnlyDraft(Draft draft)
        {
            _draft = draft;
        }
    }
}
