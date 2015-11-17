using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Core;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;
using Raunstrup.Core.statistics;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProjectComparison();
            Console.ReadKey();
        }

        private static void TestProjectComparison()
        {
            LineItem glas = new Material("glas");
            LineItem tree = new Material("træ");
            LineItem croc = new Material("krokodille");
            Project proc1 = new Project(new Draft());
            proc1.GetDraft().AddOrderLine(glas, 3);
            proc1.GetDraft().AddOrderLine(tree, 27);
            proc1.GetDraft().AddOrderLine(croc, 3);
            proc1.GetDraft().AddOrderLine(glas, 6);
            Report report1 = new Report();
            report1.AddReportLine(glas, 3);
            report1.AddReportLine(glas, 1);
            report1.AddReportLine(tree, 20);
            Report report2 = new Report();
            report2.AddReportLine(tree, 7);
            List<Report> reports = new List<Report>();
            reports.Add(report1);
            reports.Add(report2);
            ProjectComparison comparison = new ProjectComparison(proc1, new ReportRepository());
            comparison.Print();
        }
    }
}
