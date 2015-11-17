using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
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
