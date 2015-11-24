using System;
using System.IO;
using Raunstrup.Core;
using Raunstrup.Core.statistics;
using Raunstrup.Core.Xml;
using Raunstrup.Model;

namespace Test
{
    class Program
    {
        private static Company _company;

        static void Main(string[] args)
        {
            _company = new Company();

            SetupTestData();
            TestProjectComparison();

            Console.WriteLine();
            //TestParser();

            InvoiceFilePrinter filePrinter = new InvoiceFilePrinter();

            filePrinter.PrintInvoice(_company.DraftRepository.Get(1));

            Console.ReadKey();
        }

        static void SetupTestData()
        {
            SetupProducts();
            SetupCustomers();
            SetupEmployees();
            SetupDrafts();
            SetupProjects();
            SetupReports();
        }

        static void SetupProducts()
        {
            var products = new[]
            {
                new Product { Name = "Foo", SalesPrice = 123.4M }, 
                new Product { Name = "Bar", SalesPrice = 200M }, 
                new Product { Name = "Baz", SalesPrice = 321.2M }, 
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
                new Customer { Name = "Kunde #1" },
                new Customer { Name = "Kunde #2" },
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
                new Employee { Name = "Emil" },
                new Employee { Name = "Tobias" },
                new Employee { Name = "Simon" },
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
                    Title = "Draft #1", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(1)
                },
                new Draft(_company.CustomerRepository.Get(1))
                {
                    Title = "Draft #2", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(2)
                },
                new Draft(_company.CustomerRepository.Get(2))
                {
                    Title = "Draft #3", 
                    ResponsiblEmployee = _company.EmployeeRepository.Get(3)
                },
                new Draft(_company.CustomerRepository.Get(2))
                {
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
                new Project(_company.DraftRepository.Get(1)), 
                new Project(_company.DraftRepository.Get(2)), 
                new Project(_company.DraftRepository.Get(3)), 
            };

            foreach (var project in projects)
            {
                _company.ProjectRepository.Save(project);
            }
        }

        static void SetupReports()
        {
            var reports = new[]
            {
                new Report(_company.EmployeeRepository.Get(1), _company.ProjectRepository.Get(1))
                {
                    Date = _company.ProjectRepository.Get(1).OrderDate.AddDays(1)
                },
                new Report(_company.EmployeeRepository.Get(2), _company.ProjectRepository.Get(1))
                {
                    Date = _company.ProjectRepository.Get(1).OrderDate.AddDays(2)
                },
                new Report(_company.EmployeeRepository.Get(2), _company.ProjectRepository.Get(2))
                {
                    Date = _company.ProjectRepository.Get(2).OrderDate.AddDays(2)
                },
                new Report(_company.EmployeeRepository.Get(3), _company.ProjectRepository.Get(2))
                {
                    Date = _company.ProjectRepository.Get(2).OrderDate.AddDays(4)
                },
            };

            reports[0].AddReportLine(_company.ProductRepository.Get(1), 4);
            reports[0].AddReportLine(_company.ProductRepository.Get(3), 2);
            reports[0].AddReportLine(_company.ProductRepository.Get(2), 1);

            reports[1].AddReportLine(_company.ProductRepository.Get(3), 4);
            reports[1].AddReportLine(_company.ProductRepository.Get(2), 6);

            reports[2].AddReportLine(_company.ProductRepository.Get(3), 7);

            reports[3].AddReportLine(_company.ProductRepository.Get(2), 2);
            reports[3].AddReportLine(_company.ProductRepository.Get(3), 4);
            reports[3].AddReportLine(_company.ProductRepository.Get(1), 7);

            foreach (var report in reports)
            {
                _company.ReportRepository.Save(report);
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
            var comparison = new ProjectComparison(_company.ProjectRepository.Get(1), _company.ReportRepository);

            // Print Lines
            foreach (var line in comparison.GetComparisonLines())
            {
                line.PrintLine();
            }
            //Print total
            Console.WriteLine(comparison.GetTotalPercent());
        }
    }
}
