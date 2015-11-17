﻿using System.Collections.Generic;
using System.Linq;

namespace Raunstrup.Core.Repositories
{
    abstract class GenericInMemoryStorage<T>
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
