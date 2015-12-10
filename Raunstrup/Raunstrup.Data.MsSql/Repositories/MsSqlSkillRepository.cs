using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlSkillRepository : ISkillRepository
    {
        private readonly DataContext _context;
        private readonly SkillMapper _mapper;

        public MsSqlSkillRepository(DataContext context)
        {
            _context = context;
            _mapper = new SkillMapper(_context);
        }

        public Skill Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Skill> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Skill entity)
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

        public void Delete(Skill entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
