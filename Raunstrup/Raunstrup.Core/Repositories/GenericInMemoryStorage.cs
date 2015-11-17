using System.Collections.Generic;

namespace Raunstrup.Core.Repositories
{
    abstract class GenericInMemoryStorage<TKey, TValue>
    {
        protected readonly IDictionary<TKey, TValue> Storage = new Dictionary<TKey, TValue>();

        public TValue Get(TKey id)
        {
            TValue entity;

            if (Storage.TryGetValue(id, out entity))
            {
                return entity;
            }

            throw new KeyNotFoundException();
        }

        public void Save(TValue entity)
        {
            Storage.Add(GetKey(entity), entity);
        }

        public void Delete(TValue entity)
        {
            Storage.Remove(GetKey(entity));
        }

        protected abstract TKey GetKey(TValue entity);
    }
}
