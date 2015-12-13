using System;
using System.Configuration;
using System.Data.Common;
using Raunstrup.Core.Controllers;
using Raunstrup.Data.MsSql;
using Raunstrup.Data.MsSql.Repositories;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core
{
    public class Company
    {
        private readonly IDraftRepository _draftRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISkillRepository _skillRepository;

        public Company()
        {
            
            // Bootstrapping the DataContext
            var con = ConfigurationManager.ConnectionStrings["Raunstrup"];
            var provider = DbProviderFactories.GetFactory(con.ProviderName);

            var connection = provider.CreateConnection();
            connection.ConnectionString = con.ConnectionString;

            var context = new DataContext(provider, con.ConnectionString);

            _draftRepository = new MsSqlDraftRepository(context);
            _projectRepository = new MsSqlProjectRepository(context);
            _customerRepository = new MsSqlCustomerRepository(context);
            _reportRepository = new MsSqlReportRepository(context);
            _employeeRepository = new MsSqlEmployeeRepository(context);
            _productRepository = new MsSqlProductRepository(context);
            _skillRepository = new MsSqlSkillRepository(context);
            //SetupTestData();
        }

        public ReportController CreateReportController()
        {
            return new ReportController(_reportRepository,_projectRepository, _draftRepository, _employeeRepository,_productRepository);
        }

        public DraftController CreateDraftController()
        {
            return new DraftController(_customerRepository,_employeeRepository,_productRepository,_draftRepository);
        }

        public ProductCRUDController CreateProductController()
        {
            return new ProductCRUDController(_productRepository);
        }

        public EmployeeCRUDController CreateEmployeeCRUDController()
        {
            return new EmployeeCRUDController(_employeeRepository, _skillRepository);
        }

        public CustomerCRUDController CreateCustomerCRUDController()
        {
            return new CustomerCRUDController(_customerRepository);
        }

        public string Name { get; set; }
        public string Address { get; set; }

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
                new Transport { Name = "Fucking volvo", SalesPrice = 4.2M },
            };

            foreach (var product in products)
            {
                _productRepository.Save(product);
            }
        }

        private void SetupCustomers()
        {
            var customers = new[]
            {
                new Customer { Name = "Kunde #1", City = "Fuck", PostalCode = "4124", StreetNumber = "4f", StreetName = "Pis lorte test data" },
                new Customer { Name = "Kunde #2", City = "Sur røv", PostalCode = "3125", StreetNumber = "51", StreetName = "Stinker lidt af Emils navle" },
            };

            foreach (var customer in customers)
            {
                _customerRepository.Save(customer);
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
                _employeeRepository.Save(employee);
            }
        }

        private void SetupDrafts()
        {
            var drafts = new[]
            {
                new Draft(_customerRepository.Get(1))
                {
                    Title = "Draft #1", 
                    ResponsiblEmployee = _employeeRepository.Get(1),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "Fyldning af Tobias ører."
                },
                new Draft(_customerRepository.Get(1))
                {
                    Title = "Draft #2", 
                    ResponsiblEmployee = _employeeRepository.Get(2),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "Lapning af Simons mund."
                },
                new Draft(_customerRepository.Get(2))
                {
                    Title = "Draft #3", 
                    ResponsiblEmployee = _employeeRepository.Get(3),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "Udsugning af Emils bussemænd."
                },
                new Draft(_customerRepository.Get(2))
                {
                    Title = "Draft #4", 
                    ResponsiblEmployee = _employeeRepository.Get(1),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "Seppoku."
                },
            };

            drafts[0].AddOrderLine(_productRepository.Get(1), 2);
            drafts[0].AddOrderLine(_productRepository.Get(2), 3);
            drafts[0].AddOrderLine(_productRepository.Get(3), 1);

            drafts[1].AddOrderLine(_productRepository.Get(1), 5);

            drafts[2].AddOrderLine(_productRepository.Get(1), 3);
            drafts[2].AddOrderLine(_productRepository.Get(2), 6);

            drafts[0].AddOrderLine(_productRepository.Get(1), 1);
            drafts[0].AddOrderLine(_productRepository.Get(2), 6);
            drafts[0].AddOrderLine(_productRepository.Get(3), 3);

            foreach (var draft in drafts)
            {
                _draftRepository.Save(draft);
            }
        }

        private void SetupProjects()
        {
            var projects = new[]
            {
                new Project(_draftRepository.Get(1)), 
                new Project(_draftRepository.Get(2)), 
                new Project(_draftRepository.Get(3))
            };

            foreach (var project in projects)
            {
                _projectRepository.Save(project);
            }
        }

        private void SetupReports()
        {
            var reports = new[]
            {
                new Report(_employeeRepository.Get(1), _projectRepository.Get(1))
                {
                    Date = _projectRepository.Get(1).OrderDate.AddDays(1)
                },
                new Report(_employeeRepository.Get(2), _projectRepository.Get(1))
                {
                    Date = _projectRepository.Get(1).OrderDate.AddDays(2)
                },
                new Report(_employeeRepository.Get(2), _projectRepository.Get(2))
                {
                    Date = _projectRepository.Get(2).OrderDate.AddDays(2)
                },
                new Report(_employeeRepository.Get(3), _projectRepository.Get(2))
                {
                    Date = _projectRepository.Get(2).OrderDate.AddDays(4)
                },
                new Report(_employeeRepository.Get(2), _projectRepository.Get(2))
                {
                    Date = _projectRepository.Get(2).OrderDate.AddDays(3)
                },
                new Report(_employeeRepository.Get(2), _projectRepository.Get(2))
                {
                    Date = _projectRepository.Get(2).OrderDate.AddDays(4)
                },
                new Report(_employeeRepository.Get(2), _projectRepository.Get(2))
                {
                    Date = _projectRepository.Get(2).OrderDate.AddDays(5)
                },
            };

            reports[0].AddReportLine(_productRepository.Get(1), 4);
            reports[0].AddReportLine(_productRepository.Get(3), 2);
            reports[0].AddReportLine(_productRepository.Get(2), 1);

            reports[1].AddReportLine(_productRepository.Get(3), 4);
            reports[1].AddReportLine(_productRepository.Get(2), 6);

            reports[2].AddReportLine(_productRepository.Get(3), 7);

            reports[3].AddReportLine(_productRepository.Get(2), 2);
            reports[3].AddReportLine(_productRepository.Get(3), 4);
            reports[3].AddReportLine(_productRepository.Get(1), 7);

            reports[4].AddReportLine(_productRepository.Get(3), 1);
            reports[5].AddReportLine(_productRepository.Get(3), 7);
            reports[6].AddReportLine(_productRepository.Get(3), 7);

            foreach (var report in reports)
            {
                _reportRepository.Save(report);
            }
        }
        //This should be deltede sometime
    }
}
