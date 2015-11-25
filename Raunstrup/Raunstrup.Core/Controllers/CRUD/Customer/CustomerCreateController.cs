using System;
using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Controllers.CRUD.Customer
{
    public class CustomerCreateController : AbstractCreateController<Model.Customer>
    {
        public CustomerCreateController(IRepository<Model.Customer> repository, Func<Model.Customer> factory) : base(repository, factory)
        {
        }
    }
}
