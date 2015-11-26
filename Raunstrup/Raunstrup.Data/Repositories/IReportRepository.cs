using System.Collections.Generic;
using Raunstrup.Data.Specifications;
using Raunstrup.Model;

namespace Raunstrup.Data.Repositories
{
    public interface IReportRepository : IRepository<Report, IReportSpecification>
    {
        IList<Report> FindByProject(Project project);

        IList<Report> FindByEmployee(Employee employee);
    }
}
