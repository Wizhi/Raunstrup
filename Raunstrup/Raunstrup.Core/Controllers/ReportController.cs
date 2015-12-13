using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Raunstrup.Core.Statistics;
using Raunstrup.Core.Xml;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Core.Controllers
{
    public class ReportController
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDraftRepository _draftRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;

        public ReportController(IReportRepository reportRepository, IProjectRepository projectRepository, IDraftRepository draftRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository)
        {
            _reportRepository = reportRepository;
            _projectRepository = projectRepository;
            _draftRepository = draftRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }

        public ProjectComparison GetProjectComparison(int projectId)
        {
            return new ProjectComparison(_projectRepository.Get(projectId), _reportRepository);
        }

        public EmployeeStatistics GetHoursWorkedStatistics(int employeeId, DateTime start, DateTime end)
        {
            return new EmployeeStatistics(_reportRepository, _employeeRepository.Get(employeeId),start,end);
        }

        public List<ReadOnlyEmployee> GetAllEmployees()
        {
            return _employeeRepository.GetAll().Select(employee => new ReadOnlyEmployee(employee)).ToList();
        } 

        public void ReadReport(string path)
        {
            try
            {
                var xml = File.ReadAllText(path);
                var parser = new XmlReportParser(_projectRepository, _employeeRepository, _productRepository);
                var report = parser.Parse(xml);
                
                // TODO: Figure out a better way of handling "dynamic" offers. This is ugly.
                if (report.Project.Draft.Type == Draft.DraftType.Dynamic)
                {
                    foreach (var reportLine in report.ReportLines)
                    {
                        report.Project.Draft.OrderLines.Add(new OrderLine(reportLine.Product, reportLine.Quantity));
                    }
                }

                _draftRepository.Save(report.Project.Draft);
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
