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
    public class CustomerCRUDController
    {
        private Customer _currentCustomer;
        private readonly ICustomerRepository _customerRepository;

        public CustomerCRUDController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<ReadOnlyCustomer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers.Select(customer => new ReadOnlyCustomer(customer)).ToList();
        }

        public ReadOnlyCustomer GetCustomer()
        {
            return new ReadOnlyCustomer(_currentCustomer);
        }

        public void CreateNewCustomer()
        {
            _currentCustomer = new Customer();
        }

        public void EditCustomer(int id)
        {
            _currentCustomer = _customerRepository.Get(id);
        }

        public void SaveCustomer()
        {
            _customerRepository.Save(_currentCustomer);
        }

        public void DeleteCustomer()
        {
            _customerRepository.Delete(_currentCustomer);
        }

        public void SetName(string name)
        {
            _currentCustomer.Name = name;
        }

        public void SetStreet(string streetName, string streetNumber)
        {
            _currentCustomer.StreetName = streetName;
            _currentCustomer.StreetNumber = streetNumber;
        }

        public void SetCity(string city, string postalCode)
        {
            _currentCustomer.City = city;
            _currentCustomer.PostalCode = postalCode;
        }
    }
}
