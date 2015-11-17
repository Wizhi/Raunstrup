using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class DraftRepository : GenericInMemoryStorage<int, Draft>, IDraftRepository
    {
        protected override int GetKey(Draft entity)
        {
            return entity.Id;
        }
    }
}
