using System;
using System.Collections.Generic;
using System.Linq;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyProject
    {
        private readonly Project _project;
        private readonly Lazy<ReadOnlyDraft> _lazyDraft; 
        private readonly Lazy<IList<ReadOnlyEmployee>> _lazyEmployees; 

        public ReadOnlyProject(Project project)
        {
            _project = project;
            _lazyDraft = new Lazy<ReadOnlyDraft>(() => new ReadOnlyDraft(_project.Draft));
            _lazyEmployees = new Lazy<IList<ReadOnlyEmployee>>(() => _project.Employees.Select(employee => new ReadOnlyEmployee(employee)).ToList());
        }

        public int Id
        {
            get { return _project.Id; }
        }

        public ReadOnlyDraft Draft
        {
            get { return _lazyDraft.Value; }
        }

        public DateTime OrderDate
        {
            get { return _project.OrderDate; }
        }

        public IList<ReadOnlyEmployee> Employees
        {
            get { return _lazyEmployees.Value; }
        }
    }
}
