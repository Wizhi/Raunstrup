using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.InMemory.Repositories
{
    public class ProjectRepository : GenericInMemoryStorage<Project>, IProjectRepository
    {
        protected override void SetId(Project entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Project entity)
        {
            return entity.Id;
        }
    }
}
