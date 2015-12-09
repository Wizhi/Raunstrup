using System;
using System.Collections.Generic;
using System.IO;
using Raunstrup.Core.Statistics;
using Raunstrup.Core.Xml;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        // TODO Consider Inversion of Control instead of all these.
        // Kan vi ikke bare gemme alle vores repos i Company, og så skal hver
        // controller havde en reference til store
        // vi kan også bruge company til at gemme alle vores controllere
        // så på den måde bliver company det centrale "acces point" til hele bussiness logikken
        private readonly IReportRepository _reportRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;

        public ReportController(IReportRepository reportRepository, IProjectRepository projectRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository)
        {
            _reportRepository = reportRepository;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }

        public ProjectComparison GetProjectComparison(int projectId)
        {
            var project = _projectRepository.Get(projectId);
            return new ProjectComparison(project, _reportRepository);
        }

        public EmployeeStatistics GetHoursWorkedStatistics(int employeeID, DateTime start, DateTime end)
        {
            return new EmployeeStatistics(_reportRepository,_employeeRepository.Get(employeeID),start,end);
        }

        public List<ReadOnlyEmployee> GetAllEmployees()
        {
            IList<Employee> employees = _employeeRepository.GetAll();
            List<ReadOnlyEmployee> returnList = new List<ReadOnlyEmployee>();
            foreach (var employee in employees)
            {
                returnList.Add(new ReadOnlyEmployee(employee));
            }
            return returnList;
        } 

        public void UploadReport(string path)
        {
            try
            {
                var xml = File.ReadAllText(path);
                var parser = new XmlReportParser(_projectRepository, _employeeRepository, _productRepository);
                var report = parser.Parse(xml);

                _reportRepository.Save(report);
            }
            catch (FileNotFoundException)
            {
                // TODO: Handle file not found.
            }
            catch (Exception)
            {
                // TODO: Handle all the other damn exceptions.
            }
        }
    }
}
