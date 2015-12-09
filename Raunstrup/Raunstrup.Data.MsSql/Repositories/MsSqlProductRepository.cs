using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly ProductMapper _mapper;

        public MsSqlProductRepository(DataContext context)
        {
            _context = context;
            _mapper = new ProductMapper(_context);
        }

        public Product Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Product> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Product entity)
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

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
