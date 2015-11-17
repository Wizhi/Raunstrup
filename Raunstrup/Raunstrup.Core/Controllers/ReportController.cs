using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;
using Raunstrup.Core.statistics;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        ReportRepo _reportRepo;
        public ReportController(ReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }
        public ProjectComparison GetProjectComparison(Project project)
        {
            return new ProjectComparison(project, _reportRepo);
        }
    }
}
