using System.Collections.Generic;
using Raunstrup.Model;

namespace Raunstrup.Core.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
        IList<Report> FindByProject(Project project);
    }
}
