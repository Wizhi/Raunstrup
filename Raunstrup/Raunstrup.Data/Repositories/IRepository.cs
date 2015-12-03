using System.Collections;
using System.Collections.Generic;

namespace Raunstrup.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
