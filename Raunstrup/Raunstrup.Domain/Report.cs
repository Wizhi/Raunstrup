using System;
using System.Collections.Generic;

namespace Raunstrup.Domain
{
    public class Report
    {
        private int _id;
        
        public Report(Employee employee, Project project)
        {
            Employee = employee;
            Project = project;
            Date = DateTime.Now;
            ReportLines = new List<ReportLine>();
        }

        public virtual int Id
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

        public virtual Employee Employee { get; private set; }
        public virtual Project Project { get; private set; }
        public virtual DateTime Date { get; set; }
        public virtual IList<ReportLine> ReportLines { get; private set; } 

        public void AddReportLine(Product item, int quantity)
        {
            ReportLines.Add(new ReportLine(item,quantity));
        }
    }

}
