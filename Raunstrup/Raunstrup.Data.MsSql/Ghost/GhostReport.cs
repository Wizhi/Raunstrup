using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Ghost
{
    class GhostReport : Report
    {
        private readonly Lazy<IList<ReportLine>> _reportLines;

        public GhostReport(Employee employee, Project project, Func<IList<ReportLine>> reportLines)
            : base(employee, project)
        {
            _reportLines = new Lazy<IList<ReportLine>>(reportLines);
        }

        public override IList<ReportLine> ReportLines { get { return _reportLines.Value; } }
    }
}
