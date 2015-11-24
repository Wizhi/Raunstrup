using System;
using System.IO;
using Raunstrup.Core.Repositories;
using Raunstrup.Core.statistics;
using Raunstrup.Core.Xml;
using Raunstrup.Model;

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
