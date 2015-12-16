using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.MsSql.Queries;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlReportRepository : IReportRepository
    {
        private readonly DataContext _context;
        private readonly ReportMapper _mapper;

        public MsSqlReportRepository(DataContext context)
        {
            _context = context;
            _mapper = new ReportMapper(_context);
        }

        public Report Get(int id)
        {
            return _mapper.Get(id);
        }

        public IList<Report> GetAll()
        {
            return _mapper.GetAll();
        }

        public void Save(Report entity)
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

        public void Delete(Report entity)
        {
            throw new NotImplementedException();
        }

        public IList<Report> FindByProject(Project project)
        {
            return _mapper.Query(new ReportByProjectQuery(project));
        }

        public IList<Report> FindByDurationAndEmployee(DateTime start, DateTime end, Employee employee)
        {
            return _mapper.Query(new ReportByDurationAndEmployeeQuery(start, end, employee));
        }
    }
}
