using System.Collections.Generic;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.InMemory.Repositories
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

        public IList<Draft> GetDraftsAssociatedWithAProject()
        {
            throw new System.NotImplementedException();
        }
    }
}
