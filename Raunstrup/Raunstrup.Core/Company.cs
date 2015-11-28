using System.Collections.Specialized;
using Raunstrup.Core.Controllers;
using Raunstrup.Core.Repositories;

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
        }

        public ReportController GetReportController()
        {
            return new ReportController(ReportRepository,ProjectRepository,EmployeeRepository,ProductRepository);
        }

        public DraftController GetDraftController()
        {
            return new DraftController(CustomerRepository,EmployeeRepository,ProductRepository,DraftRepository);
        }
    }
}
