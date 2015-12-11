using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlEmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly EmployeeMapper _mapper;

        public MsSqlEmployeeRepository(DataContext context)
        {
            _context = context;
            _mapper = new EmployeeMapper(_context);
        }

        public Employee Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Employee> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Employee entity)
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

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
