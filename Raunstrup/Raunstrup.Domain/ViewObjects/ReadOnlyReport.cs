﻿using System;
using System.Collections.Generic;

namespace Raunstrup.Domain.ViewObjects
{
    public class ReadOnlyReport
    {
        private readonly Report _report;

        public ReadOnlyReport(Report report)
        {
            _report = report;
        }

        public IList<ReadOnlyReportLine> ReportLines
        {
            //Convert ReportLines into ReadOnlyReportLines
            get
            {
                IList<ReportLine> originalLines = _report.ReportLines;
                IList<ReadOnlyReportLine> returnLines = new List<ReadOnlyReportLine>();
                foreach (var line in originalLines)
                {
                    returnLines.Add(new ReadOnlyReportLine(line));
                }
                return returnLines;
            }
        }
        public int Id { get { return _report.Id; } }

        public ReadOnlyEmployee Employee
        {
            get { return new ReadOnlyEmployee(_report.Employee);}
        }

        public DateTime Date { get { return _report.Date; }}

    }
}
