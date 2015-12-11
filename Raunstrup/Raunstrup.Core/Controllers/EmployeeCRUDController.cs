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
    public class EmployeeCRUDController
    {
        private Employee _currentEmployee;
        private Skill _currentSkill;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillRepository _skillRepository;

        public EmployeeCRUDController(IEmployeeRepository employeeRepository, ISkillRepository skillRepository)
        {
            _employeeRepository = employeeRepository;
            _skillRepository = skillRepository;
        }

        public void EditEmployee(int id)
        {
            _currentEmployee = _employeeRepository.Get(id);
        }

        public void CreateNewEmployee()
        {
            _currentEmployee = new Employee();
        }

        public void SaveEmployee()
        {
            _employeeRepository.Save(_currentEmployee);
        }

        public void DeleteEmployee()
        {
            _employeeRepository.Delete(_currentEmployee);
        }

        public void EditSkill(int id)
        {
            _currentSkill = _skillRepository.Get(id);
        }

        public void CreateNewSkill()
        {
            _currentSkill = new Skill();
        }

        public void SaveSkill()
        {
            _skillRepository.Save(_currentSkill);
        }

        public void DeleteSkill()
        {
            _skillRepository.Delete(_currentSkill);
        }

        public List<ReadOnlySkill> GetAllSkills()
        {
            var skills = _skillRepository.GetAll();
            return skills.Select(skill => new ReadOnlySkill(skill)).ToList();
        }

        public List<ReadOnlyEmployee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return employees.Select(employee => new ReadOnlyEmployee(employee)).ToList();
        }

    }
}
