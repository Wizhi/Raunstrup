using System.Data;

namespace Raunstrup.Data.MsSql.Query
{
    interface IQuery<T>
    {
        T Execute(DataContext context);
    }
}
