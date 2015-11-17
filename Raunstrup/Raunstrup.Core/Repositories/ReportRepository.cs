using System.Collections.Generic;
using System.Linq;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Repositories
{
    class ReportRepository : GenericInMemoryStorage<int, Report>, IReportRepository
    {
        public IList<Report> FindByProject(Project project)
        {
            return Storage.Values.Where(x => x.Project == project).ToList();
        }

        protected override int GetKey(Report entity)
        {
            return entity.Id;
        }
    }
}
