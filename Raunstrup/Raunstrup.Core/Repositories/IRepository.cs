namespace Raunstrup.Core.Repositories
{
    interface IRepository<TEntity>
    {
        TEntity Get(int id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
