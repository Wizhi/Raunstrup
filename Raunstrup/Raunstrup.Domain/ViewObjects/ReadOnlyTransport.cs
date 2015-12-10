namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyTransport : ReadOnlyProduct
    {
        public ReadOnlyTransport(Transport transport) 
            : base(transport)
        {
        }
    }
}
