using System;
using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Report
    {
        public readonly Employee Employee;
        public readonly Project Project;

        private readonly IList<ReportLine> _lines = new List<ReportLine>();

        public DateTime Date { get; set; }

        public Report(Employee employee, Project project)
        {
            Employee = employee;
            Project = project;
        }

        public IList<ReportLine> GetLines()
        {
            return _lines;
        }

        public void AddReportLine(Product item, int quantity)
        {
            _lines.Add(new ReportLine(item,quantity));
        }
    }

}
