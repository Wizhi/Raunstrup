using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;
using Raunstrup.Core.statistics;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        ReportRepo reportRepo;
        public ReportController(ReportRepo reportRepo)
        {
            this.reportRepo = reportRepo;
        }
        public ProjectComparison getProjectComparison(Project project)
        {
            return new ProjectComparison(project, reportRepo);
        }
    }
}
