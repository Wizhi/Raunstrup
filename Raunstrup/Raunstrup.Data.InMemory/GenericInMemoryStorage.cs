using System.Collections.Generic;
using System.Linq;

namespace Raunstrup.Data.InMemory
{
    /// <summary>
    /// A simplistic way of storing objects in memory.
    /// </summary>
    /// <remarks>Only intended for light test use.</remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericInMemoryStorage<T>
    {
        protected readonly IDictionary<int, T> Storage = new Dictionary<int, T>();

        public T Get(int id)
        {
            T entity;

            if (Storage.TryGetValue(id, out entity))
            {
                return entity;
            }

            throw new KeyNotFoundException();
        }

        public IList<T> GetAll()
        {
            return new List<T>(Storage.Values);
        } 

        public void Save(T entity)
        {
            if (GetId(entity) == default(int))
            {
                SetId(entity, CreateId());
            }

            Storage[GetId(entity)] = entity;
        }

        public void Delete(T entity)
        {
            if (GetId(entity) != default(int))
            {
                Storage.Remove(GetId(entity));
            }
        }

        private int CreateId()
        {
            return Storage.Count == 0 ? 1 : Storage.Keys.Max() + 1;
        }

        protected abstract void SetId(T entity, int id);
        protected abstract int GetId(T entity);
    }
}
