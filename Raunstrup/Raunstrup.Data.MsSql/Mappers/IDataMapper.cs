using System.Collections.Generic;
using System.Data;

namespace Raunstrup.Data.MsSql.Mappers
{
    interface IDataMapper<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T Map(IDataReader reader);
    }
}
