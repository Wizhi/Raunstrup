using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlCustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly CustomerMapper _mapper;

        public MsSqlCustomerRepository(DataContext context)
        {
            _context = context;
            _mapper = new CustomerMapper(_context);
        }

        public Customer Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Customer> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Customer entity)
        {
            if (entity.Id == default(int))
            {
                _mapper.Insert(entity);
            }
            else
            {
                _mapper.Update(entity);
            }
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
