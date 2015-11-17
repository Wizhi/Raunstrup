using Raunstrup.Core.Repositories;

namespace Raunstrup.Core
{
    public class Company
    {
        public IDraftRepository DraftRepository { get; private set; }
        public IProjectRepository ProjectRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IReportRepository ReportRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public Company()
        {
            DraftRepository = new DraftRepository();
            ProjectRepository = new ProjectRepository();
            CustomerRepository = new CustomerRepository();
            ReportRepository = new ReportRepository();
            EmployeeRepository = new EmployeeRepository();
            ProductRepository = new ProductRepository();
        }
    }
}
