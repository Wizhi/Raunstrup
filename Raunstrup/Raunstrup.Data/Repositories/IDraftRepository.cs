using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.Repositories
{
    public interface IDraftRepository : IRepository<Draft>
    {
        /// <summary>
        /// Gets all <see cref="Draft"/>s, which have a <see cref="Project"/> associated with them.
        /// </summary>
        /// <returns></returns>
        IList<Draft> GetDraftsAssociatedWithAProject();

        /// <summary>
        /// Gets all <see cref="Draft"/>s, which do not have a <see cref="Project"/> associated with them.
        /// </summary>
        /// <returns></returns>
        IList<Draft> GetDraftsNotAssociatedWithAProject();
    }
}
