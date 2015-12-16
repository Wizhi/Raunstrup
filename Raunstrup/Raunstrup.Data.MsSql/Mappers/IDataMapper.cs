using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Queries;

namespace Raunstrup.Data.MsSql.Mappers
{
    interface IDataMapper<T>
    {
        /// <summary>
        /// Gets an entity by the given identifier.
        /// </summary>
        /// <remarks>While not realistic, we assume all identifiers are integers for simplicity.</remarks>
        /// <param name="id">The identifying value.</param>
        /// <returns></returns>
        T Get(int id);

        IList<T> Query(IQuery<T> query);

        IList<T> GetAll();

        T Map(IDataRecord record);

        IList<T> MapAll(IDataReader reader);
    }
}
