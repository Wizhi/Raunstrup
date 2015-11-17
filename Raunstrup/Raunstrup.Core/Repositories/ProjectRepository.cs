using System;
using System.Collections.Generic;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class ProjectRepository : IProjectRepository
    {
        private readonly IDictionary<int, Project> _storage = new Dictionary<int, Project>();

        public Project Get(int id)
        {
            Project project;

            if (_storage.TryGetValue(id, out project))
            {
                return project;
            }

            throw new KeyNotFoundException();
        }

        public void Save(Project entity)
        {
            _storage[entity.Id] = entity;
        }

        public void Delete(Project entity)
        {
            _storage.Remove(entity.Id);
        }
    }
}
