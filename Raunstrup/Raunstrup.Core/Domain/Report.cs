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

        public List<ReportLine> getLines()
        {
            return lines;
        }

        public void addReportLine(LineItem item, int quantity)
        {
            lines.Add(new ReportLine(item,quantity));
        }
    }

}
