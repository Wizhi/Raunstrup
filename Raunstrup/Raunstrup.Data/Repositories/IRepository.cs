using System.Collections.Generic;

namespace Raunstrup.Data.Repositories
{
    /// <summary>
    /// A collection-like interface allowing for the buisness logic to stay ignorant of persistence logic.
    /// </summary>
    /// <remarks>
    /// This isn't a true repository implementation as it lacks the querying capabilities of real repositories.
    /// This was a planned feature, but turned out to be more of a challenge than expected.
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity stored in the repository.</typeparam>
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
