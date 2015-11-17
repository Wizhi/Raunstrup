namespace Raunstrup.Core.Repos
{
    interface IRepository<in TIdentifier, TEntity>
    {
        TEntity Get(TIdentifier id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
