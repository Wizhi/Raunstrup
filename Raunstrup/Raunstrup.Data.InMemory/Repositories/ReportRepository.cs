using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Data.InMemory.Repositories
{
    public class ReportRepository : GenericInMemoryStorage<Report>, IReportRepository
    {
        public IList<Report> FindByProject(Project project)
        {
            return Storage.Values.Where(x => x.Project == project).ToList();
        }

        public IList<Report> FindByDurationAndEmployee(DateTime start, DateTime end, Employee employee)
        {
            return Storage.Values.Where(x => (x.Employee == employee) && (x.Date >= start) && (x.Date <= end)).ToList();
        }

        protected override void SetId(Report entity, int id)
        {
            entity.Id = id;
        }

        protected override int GetId(Report entity)
        {
            return entity.Id;
        }
    }
}
