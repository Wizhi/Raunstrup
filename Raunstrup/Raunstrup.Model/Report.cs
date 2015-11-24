using System;
using System.Collections.Generic;

namespace Raunstrup.Model
{
    public class Report
    {
        public readonly Employee Employee;
        public readonly Project Project;

        private int _id;
        private readonly IList<ReportLine> _lines = new List<ReportLine>();

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == default(int))
                {
                    // TODO: Handle object apparently already being persisted.
                }

                _id = value;
            }
        }

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
