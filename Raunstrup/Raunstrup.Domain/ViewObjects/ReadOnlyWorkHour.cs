namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyWorkHour : ReadOnlyProduct
    {
        public ReadOnlyWorkHour(WorkHour workHour) 
            : base(workHour)
        {
        }
    }
}
