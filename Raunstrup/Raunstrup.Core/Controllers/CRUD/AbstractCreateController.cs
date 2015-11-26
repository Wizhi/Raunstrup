using System;
using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Controllers.CRUD
{
    public abstract class AbstractCreateController<T>
    {
        protected T Entity { get; private set; }

        private readonly IRepository<T> _repository;
        private readonly Func<T> _factory;

        public AbstractCreateController(IRepository<T> repository, Func<T> factory)
        {
            _repository = repository;
            _factory = factory;

            NewEntity();
        }

        public void NewEntity()
        {
            Entity = _factory();
        }

        public void Save()
        {
            _repository.Save(Entity);

            // TODO: Consider what state the controller should be in now.
            NewEntity();
        }
    }
}
