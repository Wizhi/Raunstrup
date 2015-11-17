using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Core.Domain;
using Raunstrup.Core.statistics;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            LineItem glas = new Material("glas");
            LineItem tree = new Material("træ");
            LineItem croc = new Material("krokodille");
            Project proc1 = new Project(new Draft());
            proc1.GetDraft().addOrderLine(glas, 3);
            proc1.GetDraft().addOrderLine(tree, 27);
            proc1.GetDraft().addOrderLine(croc, 3);
            proc1.GetDraft().addOrderLine(glas, 6);
            Report report1 = new Report();
            report1.addReportLine(glas, 3);
            report1.addReportLine(glas, 1);
            report1.addReportLine(tree, 20);
            Report report2 = new Report();
            report2.addReportLine(tree, 7);
            List<Report> reports = new List<Report>();
            reports.Add(report1);
            reports.Add(report2);
            ProjectComparison comparison = new ProjectComparison(proc1, reports);
            comparison.print();
            Console.ReadKey();
        }
    }
}
