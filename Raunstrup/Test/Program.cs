using System;
using System.IO;
using Raunstrup.Core;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Xml;

namespace Test
{
    class Program
    {
        private static Company _company;

        static void Main(string[] args)
        {
            _company = new Company();

            SetupTestData();
            TestParser();
            Console.ReadKey();
        }

        static void SetupTestData()
        {
            SetupProducts();
            SetupCustomers();
            SetupEmployees();
            SetupDrafts();
            SetupProjects();
        }

        static void SetupProducts()
        {
            var products = new[]
            {
                new Product { Id = 1, Name = "Foo", SalesPrice = 123.4M }, 
                new Product { Id = 2, Name = "Bar", SalesPrice = 200M }, 
                new Product { Id = 3, Name = "Baz", SalesPrice = 321.2M }, 
            };

            foreach (var product in products)
            {
                _company.ProductRepository.Save(product);
            }
        }

        static void SetupCustomers()
        {
            var customers = new[]
            {
                new Customer { Id = 1, Name = "Kunde #1" },
                new Customer { Id = 2, Name = "Kunde #2" },
            };

            foreach (var customer in customers)
            {
                _company.CustomerRepository.Save(customer);
            }
        }

        static void SetupEmployees()
        {
            var employees = new[]
            {
                new Employee { Id = 1, Name = "Emil" },
                new Employee { Id = 2, Name = "Tobias" },
                new Employee { Id = 3, Name = "Simon" },
            };

            foreach (var employee in employees)
            {
                _company.EmployeeRepository.Save(employee);
            }
        }

        static void SetupDrafts()
        {
            var drafts = new[]
            {
                new Draft(_company.CustomerRepository.Get(1))
                {
                    Id = 1,
                    Title = "Draft #1", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(1)
                },
                new Draft(_company.CustomerRepository.Get(1))
                {
                    Id = 2,
                    Title = "Draft #2", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(2)
                },
                new Draft(_company.CustomerRepository.Get(2))
                {
                    Id = 3,
                    Title = "Draft #3", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(3)
                },
                new Draft(_company.CustomerRepository.Get(2))
                {
                    Id = 4,
                    Title = "Draft #4", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(1)
                },
            };

            drafts[0].AddOrderLine(_company.ProductRepository.Get(1), 2);
            drafts[0].AddOrderLine(_company.ProductRepository.Get(2), 3);
            drafts[0].AddOrderLine(_company.ProductRepository.Get(3), 1);

            drafts[1].AddOrderLine(_company.ProductRepository.Get(1), 5);

            drafts[2].AddOrderLine(_company.ProductRepository.Get(1), 3);
            drafts[2].AddOrderLine(_company.ProductRepository.Get(2), 6);

            drafts[0].AddOrderLine(_company.ProductRepository.Get(1), 1);
            drafts[0].AddOrderLine(_company.ProductRepository.Get(2), 6);
            drafts[0].AddOrderLine(_company.ProductRepository.Get(3), 3);

            foreach (var draft in drafts)
            {
                _company.DraftRepository.Save(draft);
            }
        }

        static void SetupProjects()
        {
            var projects = new[]
            {
                new Project(_company.DraftRepository.Get(1)) { Id = 1 }, 
                new Project(_company.DraftRepository.Get(2)) { Id = 2 }, 
                new Project(_company.DraftRepository.Get(3)) { Id = 3 }, 
            };

            foreach (var project in projects)
            {
                _company.ProjectRepository.Save(project);
            }
        }

        static void TestParser()
        {
            var parser = new XmlReportParser(_company.ProjectRepository, _company.EmployeeRepository, _company.ProductRepository);

            var report = parser.Parse(File.ReadAllText("report.xml"));

            Console.WriteLine(report.Date);

            foreach (var reportLine in report.GetLines())
            {
                Console.WriteLine("{0}x{1}", reportLine.GetLineItem().Name, reportLine.GetQuantity());
            }
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
            ProjectComparison comparison = new ProjectComparison(proc1, new ReportRepository());
            comparison.Print();
             * */
        }
    }
}
