using System;
using System.Collections.Generic;
using System.Linq;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyProject
    {
        private readonly Project _real;
        private readonly Lazy<ReadOnlyDraft> _lazyDraft; 
        private readonly Lazy<IList<ReadOnlyEmployee>> _lazyEmployees; 

        public ReadOnlyProject(Project real)
        {
            _real = real;
            _lazyDraft = new Lazy<ReadOnlyDraft>(() => new ReadOnlyDraft(_real.Draft));
            _lazyEmployees = new Lazy<IList<ReadOnlyEmployee>>(() => _real.Employees.Select(employee => new ReadOnlyEmployee(employee)).ToList());
        }

        public int Id
        {
            get { return _real.Id; }
        }

        public ReadOnlyDraft Draft
        {
            get { return _lazyDraft.Value; }
        }

        public DateTime OrderDate
        {
            get { return _real.OrderDate; }
        }

        public IList<ReadOnlyEmployee> Employees
        {
            get { return _lazyEmployees.Value; }
        }
    }
}
