namespace Raunstrup.Domain.ViewObjects
{
    class ReadOnlyTransport : ReadOnlyProduct
    {
        public ReadOnlyTransport(Transport transport) 
            : base(transport)
        {
        }
    }
}
