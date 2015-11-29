using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Core.Controllers
{
    public class DraftController
    {
        private Draft _currentDraft;
        private readonly Company _company;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDraftRepository _draftRepository;

        public DraftController(ICustomerRepository customerRepository,IEmployeeRepository employeeRepository, IProductRepository productRepository, IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _employeeRepository = employeeRepository;

        }

        public void CreateNewDraft(int customerId)
        {
            var customer = _customerRepository.Get(customerId);
            _currentDraft = new Draft(customer);
        }

        public void EditDraft(int id)
        {
            _currentDraft = _draftRepository.Get(id);
        }

        public void AddOrderLine(int id, int quantity)
        {
            Product product = _productRepository.Get(id);
            _currentDraft.AddOrderLine(product,quantity);
        }

        public void SetStartDate(DateTime startDate)
        {
            _currentDraft.StartDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            _currentDraft.EndDate = endDate;
        }

        public void SetResponsibleEmployee(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            _currentDraft.ResponsiblEmployee = employee;
        }

        public void SetTitle(string title)
        {
            _currentDraft.Title = title;
        }

        public void SetDescription(string description)
        {
            _currentDraft.Description = description;
        }

        public void SaveDraft()
        {
            _draftRepository.Save(_currentDraft);
        }

        public ReadOnlyDraft GetDraft()
        {
            return new ReadOnlyDraft(_currentDraft);
        }
    }
}
