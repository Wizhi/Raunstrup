using System;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Data.MsSql.Query;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Repositories
{
    public class MsSqlReportRepository : IReportRepository
    {
        private readonly DataContext _context;
        private readonly ReportMapper _reportMapper;

        public MsSqlReportRepository(DataContext context)
        {
            _context = context;
            _reportMapper = new ReportMapper(_context);
        }

        public Report Get(int id)
        {
            return _reportMapper.Get(id);
        }

        public IList<Report> GetAll()
        {
            return _reportMapper.GetAll();
        }

        public void Save(Report entity)
        {
            if (entity.Id == default(int))
            {
                _reportMapper.Insert(entity);
            }
            else
            {
                _reportMapper.Update(entity);
            }
        }

        public void Delete(Report entity)
        {
            throw new NotImplementedException();
        }

        public IList<Report> FindByProject(Project project)
        {
            return new ReportByProjectQuery(project).Execute(_context);
        }

        public IList<Report> FindByDurationAndEmployee(DateTime start, DateTime end, Employee employee)
        {
            return new ReportByDurationAndEmployeeQuery(start, end, employee).Execute(_context);
        }
    }
}
