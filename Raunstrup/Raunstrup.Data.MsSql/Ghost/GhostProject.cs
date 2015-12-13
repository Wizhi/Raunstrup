using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class GhostProject : Project
    {
        private readonly Lazy<IList<Employee>> _lazyEmployees; 

        public GhostProject(Draft draft, Func<IList<Employee>> employeeLoader) 
            : base(draft)
        {
            _lazyEmployees = new Lazy<IList<Employee>>(employeeLoader);
        }

        public override IList<Employee> Employees
        {
            get { return _lazyEmployees.Value; }
        }
    }
}