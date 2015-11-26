using System.Collections.Generic;
using Raunstrup.Data.Specifications;

namespace Raunstrup.Data.Repositories
{
    public interface IRepository<T, out K>
        where K : ISpecification<T>
    {
        K Specify();

        T Get(int id);

        IEnumerable<T> GetAll(); 

        void Save(T entity);

        void Delete(T entity);
    }
}
