using System;
using System.Collections.Generic;
using System.Linq;
using Raunstrup.Domain;

namespace Raunstrup.Core.Repositories
{
    public class ReportRepository : GenericInMemoryStorage<Report>, IReportRepository
    {
        public IList<Report> FindByProject(Project project)
        {
            return Storage.Values.Where(x => x.Project == project).ToList();
        }

        public IList<Report> FindByDurationAndEmployee(DateTime start, DateTime end, Employee employee)
        {
            throw new NotImplementedException();
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
