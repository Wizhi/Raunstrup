using System;
using System.IO;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repositories;
using Raunstrup.Core.statistics;
using Raunstrup.Core.Xml;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        // TODO: Consider Inversion of Control instead of all these.
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

        public ProjectComparison GetProjectComparison(Project project)
        {
            return new ProjectComparison(project, _reportRepository);
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
