using System.Collections.Generic;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyEmployee
    {
        private readonly Employee _employee;

        public ReadOnlyEmployee(Employee employee)
        {
            _employee = employee;
        }
        public int Id
        {
            get { return _employee.Id; }
        }

        public string Name
        {
            get { return _employee.Name; }
        }

        public IList<Skill> Skills
        {
            get { return _employee.Skills; }
        }
    }
}
