using System.Collections.Generic;
using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Controllers.CRUD
{
    abstract class AbstractListController<T>
    {
        private readonly IRepository<T> _repository;

        public AbstractListController(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetEntities()
        {
            return _repository.GetAll();
        }
    }
}
