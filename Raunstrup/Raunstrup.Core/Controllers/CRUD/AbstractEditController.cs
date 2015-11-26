using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Controllers.CRUD
{
    abstract class AbstractEditController<T>
    {
        protected readonly T Entity;

        private readonly IRepository<T> _repository;

        public AbstractEditController(IRepository<T> repository, T entity)
        {
            _repository = repository;
            Entity = entity;
        }

        public void Save()
        {
            _repository.Save(Entity);
        }
    }
}
