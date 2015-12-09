using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        private readonly ProjectMapper _mapper;

        public MsSqlProjectRepository(DataContext context)
        {
            _context = context;
            _mapper = new ProjectMapper(context);
        }

        public Project Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Project> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Project entity)
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

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
