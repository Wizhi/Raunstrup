using System;
using System.Collections.Generic;

namespace Raunstrup.Core.Domain
{
    public class Report
    {
        private DateTime _date;
        private Employee _employee;
        private Project _project;
        private List<ReportLine> _lines = new List<ReportLine>();

        public List<ReportLine> GetLines()
        {
            return _lines;
        }

        public void AddReportLine(LineItem item, int quantity)
        {
            _lines.Add(new ReportLine(item,quantity));
        }
    }

}
