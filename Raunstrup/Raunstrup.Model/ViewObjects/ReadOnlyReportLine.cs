using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Model.ViewObjects
{
    public class ReadOnlyReportLine
    {
        private readonly ReportLine _reportLine;

        public ReadOnlyReportLine(ReportLine reportLine)
        {
            _reportLine = reportLine;
        }

        public ReadOnlyProduct Product
        {
            get { return new ReadOnlyProduct(_reportLine.Item);}
        }

        public int Quantity
        {
            get { return _reportLine.Quantity; }
        }
    }
}
