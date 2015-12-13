using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.Repositories
{
    public interface IDraftRepository : IRepository<Draft>
    {
        /// <summary>
        /// Gets all <see cref="Draft"/>s, which have a <see cref="Project"/> associated with them.
        /// </summary>
        /// <remarks>What in the flying fishsticks is this stupid name?</remarks>
        /// <returns>Pain.</returns>
        IList<Draft> GetDraftsAssociatedWithAProject();
    }
}
