using System.IO;
using System.Xml;
using System.Xml.Schema;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;

namespace Raunstrup.Core.Xml
{
    public class XmlReportParser
    {
        private ProductRepository productRepository;
        private EmployeeRepository employeeRepository;

        public XmlReportParser(ProductRepository productRepository, EmployeeRepository employeeRepository)
        {
            this.productRepository = productRepository;
            this.employeeRepository = employeeRepository;
        }

        public XmlDocument Parse(string xml)
        {
            var settings = new XmlReaderSettings();

            settings.Schemas.Add(@"http://raunstrup.com/EAL", @"Xml/report.xsd");
            settings.ValidationType = ValidationType.Schema;

            var reader = XmlReader.Create(new StringReader(xml), settings);
            var document = new XmlDocument();

            document.Load(reader);
            document.Validate(ValidationHandler);


            return document;
        }

        private void ValidationHandler(object sender, ValidationEventArgs validationEventArgs)
        {
            // TODO: Handle validation errors.
        }
    }
}
