namespace Raunstrup.Domain.ViewObjects
{
    class ReadOnlyWorkHour : ReadOnlyProduct
    {
        public ReadOnlyWorkHour(WorkHour workHour) 
            : base(workHour)
        {
        }
    }
}
