using System.Collections.Generic;
using System.Linq;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Core.Controllers
{
    public class ProjectController
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private Project _project;

        public ProjectController(IProjectRepository projectProjectRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectProjectRepository;
            _employeeRepository = employeeRepository;
        }

        public ReadOnlyProject Load(int id)
        {
            _project = _projectRepository.Get(id);

            // TODO: Handle Project not found.

            return new ReadOnlyProject(_project);
        }

        public void Save()
        {
            _projectRepository.Save(_project);
        }

        public IEnumerable<ReadOnlyEmployee> GetAvailableEmployees()
        {
            return _employeeRepository.GetAll()
                .Where(x => _project.Employees.Any(y => y.Id != x.Id))
                .Select(employee => new ReadOnlyEmployee(employee))
                .ToList();
        }

        public void AddEmployee(int id)
        {
            _project.Employees.Add(_employeeRepository.Get(id));
        }

        public void RemoveEmployee(int id)
        {
            _project.Employees.Remove(_project.Employees.FirstOrDefault(x => x.Id == id));
        }
    }
}
