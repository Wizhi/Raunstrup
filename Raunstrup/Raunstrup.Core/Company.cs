using Raunstrup.Core.Controllers;
using Raunstrup.Data.InMemory.Repositories;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core
{
    public class Company
    {
        private IDraftRepository DraftRepository { get; set; }
        private IProjectRepository ProjectRepository { get; set; }
        private ICustomerRepository CustomerRepository { get; set; }
        private IReportRepository ReportRepository { get; set; }
        private IEmployeeRepository EmployeeRepository { get; set; }
        private IProductRepository ProductRepository { get; set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Company()
        {
            DraftRepository = new DraftRepository();
            ProjectRepository = new ProjectRepository();
            CustomerRepository = new CustomerRepository();
            ReportRepository = new ReportRepository();
            EmployeeRepository = new EmployeeRepository();
            ProductRepository = new ProductRepository();
            SetupTestData();
        }

        public ReportController GetReportController()
        {
            return new ReportController(ReportRepository,ProjectRepository,EmployeeRepository,ProductRepository);
        }

        public DraftController GetDraftController()
        {
            return new DraftController(CustomerRepository,EmployeeRepository,ProductRepository,DraftRepository);
        }

        //All this test data should be deleted at some point, but for now it will have to be here
        private void SetupTestData()
        {
            SetupProducts();
            SetupCustomers();
            SetupEmployees();
            SetupDrafts();
            SetupProjects();
            SetupReports();
        }

        private void SetupProducts()
        {
            var products = new Product[]
            {
                new Material { Name = "Metal", SalesPrice = 123.4M, CostPrice = 50M }, 
                new Material { Name = "Wood", SalesPrice = 200M, CostPrice = 100M }, 
                new WorkHour { Name = "HandWorker Hour", SalesPrice = 321.2M }, 
            };

            foreach (var product in products)
            {
                ProductRepository.Save(product);
            }
        }

        private void SetupCustomers()
        {
            var customers = new[]
            {
                new Customer { Name = "Kunde #1" },
                new Customer { Name = "Kunde #2" },
            };

            foreach (var customer in customers)
            {
                CustomerRepository.Save(customer);
            }
        }

        private void SetupEmployees()
        {
            var employees = new[]
            {
                new Employee { Name = "Emil" },
                new Employee { Name = "Tobias" },
                new Employee { Name = "Simon" },
            };

            foreach (var employee in employees)
            {
                EmployeeRepository.Save(employee);
            }
        }

        private void SetupDrafts()
        {
            var drafts = new[]
            {
                new Draft(CustomerRepository.Get(1))
                {
                    Title = "Draft #1", 
                    ResponsiblEmployee = EmployeeRepository.Get(1)
                },
                new Draft(CustomerRepository.Get(1))
                {
                    Title = "Draft #2", 
                    ResponsiblEmployee = EmployeeRepository.Get(2)
                },
                new Draft(CustomerRepository.Get(2))
                {
                    Title = "Draft #3", 
                    ResponsiblEmployee = EmployeeRepository.Get(3)
                },
                new Draft(CustomerRepository.Get(2))
                {
                    Title = "Draft #4", 
                    ResponsiblEmployee = EmployeeRepository.Get(1)
                },
            };

            drafts[0].AddOrderLine(ProductRepository.Get(1), 2);
            drafts[0].AddOrderLine(ProductRepository.Get(2), 3);
            drafts[0].AddOrderLine(ProductRepository.Get(3), 1);

            drafts[1].AddOrderLine(ProductRepository.Get(1), 5);

            drafts[2].AddOrderLine(ProductRepository.Get(1), 3);
            drafts[2].AddOrderLine(ProductRepository.Get(2), 6);

            drafts[0].AddOrderLine(ProductRepository.Get(1), 1);
            drafts[0].AddOrderLine(ProductRepository.Get(2), 6);
            drafts[0].AddOrderLine(ProductRepository.Get(3), 3);

            foreach (var draft in drafts)
            {
                DraftRepository.Save(draft);
            }
        }

        private void SetupProjects()
        {
            var projects = new[]
            {
                new Project(DraftRepository.Get(1)), 
                new Project(DraftRepository.Get(2)), 
                new Project(DraftRepository.Get(3)), 
            };

            foreach (var project in projects)
            {
                ProjectRepository.Save(project);
            }
        }

        private void SetupReports()
        {
            var reports = new[]
            {
                new Report(EmployeeRepository.Get(1), ProjectRepository.Get(1))
                {
                    Date = ProjectRepository.Get(1).OrderDate.AddDays(1)
                },
                new Report(EmployeeRepository.Get(2), ProjectRepository.Get(1))
                {
                    Date = ProjectRepository.Get(1).OrderDate.AddDays(2)
                },
                new Report(EmployeeRepository.Get(2), ProjectRepository.Get(2))
                {
                    Date = ProjectRepository.Get(2).OrderDate.AddDays(2)
                },
                new Report(EmployeeRepository.Get(3), ProjectRepository.Get(2))
                {
                    Date = ProjectRepository.Get(2).OrderDate.AddDays(4)
                },
            };

            reports[0].AddReportLine(ProductRepository.Get(1), 4);
            reports[0].AddReportLine(ProductRepository.Get(3), 2);
            reports[0].AddReportLine(ProductRepository.Get(2), 1);

            reports[1].AddReportLine(ProductRepository.Get(3), 4);
            reports[1].AddReportLine(ProductRepository.Get(2), 6);

            reports[2].AddReportLine(ProductRepository.Get(3), 7);

            reports[3].AddReportLine(ProductRepository.Get(2), 2);
            reports[3].AddReportLine(ProductRepository.Get(3), 4);
            reports[3].AddReportLine(ProductRepository.Get(1), 7);

            foreach (var report in reports)
            {
                ReportRepository.Save(report);
            }
        }
        //This should be deltede sometime
    }
}
