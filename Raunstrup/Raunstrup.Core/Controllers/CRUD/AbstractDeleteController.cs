using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Controllers.CRUD
{
    abstract class AbstractDeleteController<T>
    {
        protected readonly T Entity;

        private readonly IRepository<T> _repository;

        public AbstractDeleteController(IRepository<T> repository, T entity)
        {
            _repository = repository;
            Entity = entity;
        }

        public void Delete()
        {
            _repository.Delete(Entity);

            // TODO: Consider what state the controller should be in now.
        }
    }
}
