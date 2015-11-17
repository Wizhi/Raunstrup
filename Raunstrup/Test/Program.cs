using System;
using Raunstrup.Core.Repos;
using Raunstrup.Core.Xml;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestParser();
            Console.ReadKey();
        }

        static void TestParser()
        {
            var parser = new XmlReportParser(new ProjectRepository(), new EmployeeRepository(), new ProductRepository());

            var report = parser.Parse(@"Xml/report.xml");
        }

        private static void TestProjectComparison()
        {
            /*
            Product glas = new Material("glas");
            Product tree = new Material("træ");
            Product croc = new Material("krokodille");
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
            ProjectComparison comparison = new ProjectComparison(proc1, new ReportRepo());
            comparison.Print();
             * */
        }
    }
}
