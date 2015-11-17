using Raunstrup.Core.Domain;
using Raunstrup.Core.statistics;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        ReportRepository _reportRepository;
        public ReportController(ReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public ProjectComparison GetProjectComparison(Project project)
        {
            return new ProjectComparison(project, _reportRepository);
        }
    }
}
