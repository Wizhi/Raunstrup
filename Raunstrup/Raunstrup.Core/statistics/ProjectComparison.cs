using System;
using System.Collections.Generic;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core.Statistics
{
    public class ProjectComparison
    {
        private Project _project;
        private readonly List<ProjectComparisonLine> _comparisonLines = new List<ProjectComparisonLine>(); 
        public ProjectComparison(Project project, IReportRepository repository)
        {
            IList<Report> reports = repository.FindByProject(project);
            _project = project;
            CompareProject(reports);
        }

        private void CompareProject(IList<Report> reports)
        {
            //Create dictionary which maps items to the amount of them in the order
            //This is neccesary because there can be multiple orderlines with them same item
            IList<OrderLine> orderLines = _project.Draft.GetOrderLines();
            Dictionary<int, int> amountsInOrderlines = new Dictionary<int, int>();
            //Creates a identity map, to map an id to a product, this is due to a weakness
            //In the dataacesse code, which create several objects repersenting the same product
            //so comparison of products have to be made by using the id, and not be using objects
            var ProductIdentityMap = new Dictionary<int, Product>();
            //Finds and maps amount of products in orderlines
            foreach (var line in orderLines)
            {
                if (amountsInOrderlines.ContainsKey(line.Product.Id))
                {
                    amountsInOrderlines[line.Product.Id] += line.Quantity;
                }
                else
                {
                    ProductIdentityMap.Add(line.Product.Id,line.Product);
                    amountsInOrderlines.Add(line.Product.Id, line.Quantity); 
                }
            }
            //Do the same for the report lines
            var amountsInReportLines = new Dictionary<int , int>();
            foreach (var report in reports)
            {
                foreach (var line in report.ReportLines)
                {
                    if (amountsInReportLines.ContainsKey(line.GetLineItem().Id))
                    {
                        amountsInReportLines[line.GetLineItem().Id] += line.Quantity;
                    }
                    else
                    {
                        amountsInReportLines.Add(line.GetLineItem().Id, line.Quantity);
                    }
                }
            }
            //Add the statistic lines
            foreach (var pair in amountsInOrderlines)
            {
                if (amountsInReportLines.ContainsKey(pair.Key))
                {
                    _comparisonLines.Add(new ProjectComparisonLine(ProductIdentityMap[pair.Key],pair.Value,amountsInReportLines[pair.Key]));
                }
                else
                {
                    _comparisonLines.Add(new ProjectComparisonLine(ProductIdentityMap[pair.Key], pair.Value, 0));
                }
            }
        }

        //Calculates the total percent of products used
        public double GetTotalPercent()
        {
            int totalOrder = 0;
            int totalUsed = 0;
            foreach (var line in _comparisonLines)
            {
                totalOrder += line.GetOrdered();
                totalUsed += line.GetUsed();
            }
            //This is about avoiding dividing by zero
            if (totalOrder == 0)
            {
                return 0;
            }
            return ((Convert.ToDouble(totalUsed) / Convert.ToDouble(totalOrder)) * 100);
        }

        public List<ProjectComparisonLine> GetComparisonLines()
        {
            return _comparisonLines;
        }
    }

    public class ProjectComparisonLine
    {
        private Product _item;
        public int AmountOrdered { get; private set; }
        public int AmountUsed { get; private set; }

        public ProjectComparisonLine(Product item, int amountOrdered, int amountUsed)
        {
            _item = item;
            AmountOrdered = amountOrdered;
            AmountUsed = amountUsed;
        }

        public double CalculatePercentage()
        {
            //Must check, to avoid dividing by zero
            if (AmountOrdered == 0)
            {
                return 0;
            }
            return (Convert.ToDouble(AmountUsed) / Convert.ToDouble(AmountOrdered)) * 100;
        }

        public void PrintLine()
        {
            Console.WriteLine(_item.Name + " : " + AmountOrdered + " : " + AmountUsed + " : " + CalculatePercentage() + "%");
        }

        public int GetOrdered()
        {
            return AmountOrdered;
        }

        public int GetUsed()
        {
            return AmountUsed;
        }

        public string GetProductName()
        {
            return _item.Name;
        }
    }
}
