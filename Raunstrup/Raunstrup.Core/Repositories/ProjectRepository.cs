using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class ProjectRepository : GenericInMemoryStorage<int, Project>, IProjectRepository
    {
        protected override int GetKey(Project entity)
        {
            return entity.Id;
        }
    }
}
