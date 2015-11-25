using Raunstrup.Model;

namespace Raunstrup.Data.Specifications
{
    public interface IReportSpecification : ISpecification<Report>
    {
        IReportSpecification ByEmployee(Employee employee);

        IReportSpecification ForProject(Project project);
    }
}
