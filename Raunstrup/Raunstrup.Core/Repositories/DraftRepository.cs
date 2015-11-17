using System.Collections.Generic;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class DraftRepository : IDraftRepository
    {
        private readonly IDictionary<int, Draft> _storage = new Dictionary<int, Draft>();

        public Draft Get(int id)
        {
            Draft draft;

            if (_storage.TryGetValue(id, out draft))
            {
                return draft;
            }

            throw new KeyNotFoundException();
        }

        public void Save(Draft entity)
        {
            _storage[entity.Id] = entity;
        }

        public void Delete(Draft entity)
        {
            _storage.Remove(entity.Id);
        }
    }
}
