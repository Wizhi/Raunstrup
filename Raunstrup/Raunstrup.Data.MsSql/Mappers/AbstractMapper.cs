using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Queries;

namespace Raunstrup.Data.MsSql.Mappers
{
    abstract class AbstractMapper<T> : IDataMapper<T>
    {
        protected readonly DataContext Context;

        public AbstractMapper(DataContext context)
        {
            Context = context;
        }

        public abstract T Get(int id);
        
        public IList<T> Query(IQuery<T> query)
        {
            using (var connection = Context.CreateConnection())
            using (var reader = query.Execute(connection))
            {
                return MapAll(reader);
            }
        }

        public abstract IList<T> GetAll();
        public abstract T Map(IDataRecord record);
        public abstract IList<T> MapAll(IDataReader reader);
    }
}
