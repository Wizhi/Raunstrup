using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Core.Domain;

namespace Raunstrup.Core.Controllers
{
    public class DraftController
    {
        private Draft _currentDraft;
        private readonly Company _company;

        public DraftController(Company company)
        {
            _company = company;
        }

        public void CreateNewDraft(Customer customer)
        {
            _currentDraft = new Draft(customer);
        }

        public void EditDraft(int id)
        {
            _currentDraft = _company.DraftRepository.Get(id);
        }

        public void AddOrderLine(int id, int quantity)
        {
            Product product = _company.ProductRepository.Get(id);
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
            Employee employee = _company.EmployeeRepository.Get(id);
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
            _company.DraftRepository.Save(_currentDraft);
        }
    }
}
