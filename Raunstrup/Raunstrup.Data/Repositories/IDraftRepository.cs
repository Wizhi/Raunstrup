using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.Repositories
{
    public interface IDraftRepository : IRepository<Draft>
    {
        IList<Draft> GetUncommittedDrafts();
    }
}
