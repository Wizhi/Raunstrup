﻿using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.InMemory.Repositories
{
    public class CustomerRepository : GenericInMemoryStorage<Customer>, ICustomerRepository
    {
        protected override void SetId(Customer entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Customer entity)
        {
            return entity.Id;
        }
    }
}
