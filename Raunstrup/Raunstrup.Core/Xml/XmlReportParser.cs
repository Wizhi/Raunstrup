using System;
using System.IO;
using System.Xml;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repositories;

namespace Raunstrup.Core.Xml
{
    public class XmlReportParser
    {
        private readonly ProjectRepository _projectRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ProductRepository _productRepository;

        public XmlReportParser(ProjectRepository projectRepository, EmployeeRepository employeeRepository, ProductRepository productRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }

        public Report Parse(string xml)
        {
            var settings = new XmlReaderSettings();

            settings.Schemas.Add(@"http://raunstrup.com/EAL", @"Xml/report.xsd");
            settings.ValidationType = ValidationType.Schema;

            var reader = XmlReader.Create(new StringReader(xml), settings);
            var document = new XmlDocument();
            
            document.Load(reader);

            var rootNode = document["report"];
            var report = new Report(
                _employeeRepository.Get(Convert.ToInt32(rootNode.Attributes["employeeId"].Value)), 
                _projectRepository.Get(Convert.ToInt32(rootNode.Attributes["projectId"].Value))
            );

            foreach (XmlNode node in document.SelectNodes(@"\report\materials"))
            {
                // TODO: Find a better way to do this, wtf.
                report.AddReportLine(
                    _productRepository.Get(Convert.ToInt32(node.Value)),
                    Convert.ToInt32(node.Attributes["quantity"])
                );
            }

            return report;
        }
    }
}
