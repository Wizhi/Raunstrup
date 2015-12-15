using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core.Xml
{
    public class XmlReportParser
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly XmlReaderSettings _settings;

        public XmlReportParser(IProjectRepository projectRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;

            _settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
            _settings.Schemas.Add(
                XmlSchema.Read(
                    Assembly
                        .GetExecutingAssembly()
                        .GetManifestResourceStream("Raunstrup.Core.Xml.report.xsd"), 
                    ValidationEventHandler
                )
            );
        }

        public Report Parse(string xml)
        {
            var reader = XmlReader.Create(new StringReader(xml), _settings);
            var document = new XmlDocument();
            
            document.Load(reader);

            var rootNode = document["report"];
            var report = new Report(
                _employeeRepository.Get(Convert.ToInt32(rootNode.Attributes["employeeId"].Value)), 
                _projectRepository.Get(Convert.ToInt32(rootNode.Attributes["projectId"].Value))
            ) { Date = DateTime.Parse(rootNode["date"].InnerText) };

            foreach (XmlNode node in rootNode["materials"].ChildNodes)
            {
                report.AddReportLine(
                    _productRepository.Get(Convert.ToInt32(node.InnerText)),
                    Convert.ToInt32(node.Attributes["quantity"].Value)
                );
            }

            return report;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs validationEventArgs)
        {
            // TODO: Implement validation error handling.
            throw new NotImplementedException();
        }
    }
}
