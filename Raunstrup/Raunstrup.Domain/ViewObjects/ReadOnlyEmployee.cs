namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyEmployee
    {
        private readonly Employee _employee;

        public ReadOnlyEmployee(Employee employee)
        {
            _employee = employee;
        }
        public string Name { get { return _employee.Name; } }
        public int Id { get { return _employee.Id; } }
    }
}
