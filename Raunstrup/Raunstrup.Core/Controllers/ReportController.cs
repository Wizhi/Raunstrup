using Raunstrup.Core.Domain;
using Raunstrup.Core.Repositories;
using Raunstrup.Core.statistics;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public ProjectComparison GetProjectComparison(Project project)
        {
            return new ProjectComparison(project, _reportRepository);
        }
    }
}
