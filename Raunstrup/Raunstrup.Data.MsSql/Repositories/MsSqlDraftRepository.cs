using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.MsSql.Query;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlDraftRepository : IDraftRepository
    {
        private readonly DataContext _context;
        private readonly DraftMapper _mapper;

        public MsSqlDraftRepository(DataContext context)
        {
            _context = context;
            _mapper = new DraftMapper(_context);
        }

        public Draft Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Draft> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Draft entity)
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

        public void Delete(Draft entity)
        {
            throw new NotImplementedException();
        }

        public IList<Draft> GetDraftsAssociatedWithAProject()
        {
            return new DraftsAssociatedWithProjectQuery().Execute(_context);
        }
    }
}
