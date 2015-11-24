using Raunstrup.Model;

namespace Raunstrup.Core.Repositories
{
    public class DraftRepository : GenericInMemoryStorage<Draft>, IDraftRepository
    {
        protected override void SetId(Draft entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Draft entity)
        {
            return entity.Id;
        }
    }
}
