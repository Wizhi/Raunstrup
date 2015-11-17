using System;
using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Report
    {
        private DateTime date;
        private Employee employee;
        private Project project;
        private List<ReportLine> lines = new List<ReportLine>();

        public Report(Project project, Employee employee)
        {
            this.project = project;
            this.employee = employee;
        }

        public List<ReportLine> getLines()
        {
            return lines;
        }

        public void addReportLine(Product item, int quantity)
        {
            lines.Add(new ReportLine(item,quantity));
        }
    }

}
