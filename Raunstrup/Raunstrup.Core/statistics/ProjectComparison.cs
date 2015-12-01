using System;
using System.Collections.Generic;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core.statistics
{
    public class ProjectComparison
    {
        private Project _project;
        private List<ProjectComparisonLine> _comparisonLines = new List<ProjectComparisonLine>(); 
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
            Dictionary<Product, int> amountsInOrderlines = new Dictionary<Product, int>();
            foreach (var line in orderLines)
            {
                if (amountsInOrderlines.ContainsKey(line.GetProduct()))
                {
                    amountsInOrderlines[line.GetProduct()] += line.GetQuantity();
                }
                else
                {
                    amountsInOrderlines.Add(line.GetProduct(), line.GetQuantity()); 
                }
            }
            //Do the same for the report lines
            Dictionary<Product, int> amountsInReportLines = new Dictionary<Product, int>();
            foreach (var report in reports)
            {
                foreach (var line in report.GetLines())
                {
                    if (amountsInReportLines.ContainsKey(line.GetLineItem()))
                    {
                        amountsInReportLines[line.GetLineItem()] += line.GetQuantity();
                    }
                    else
                    {
                        amountsInReportLines.Add(line.GetLineItem(), line.GetQuantity());
                    }
                }
            }
            //Add the statistic lines
            foreach (var pair in amountsInOrderlines)
            {
                if (amountsInReportLines.ContainsKey(pair.Key))
                {
                    _comparisonLines.Add(new ProjectComparisonLine(pair.Key,pair.Value,amountsInReportLines[pair.Key]));
                }
                else
                {
                    _comparisonLines.Add(new ProjectComparisonLine(pair.Key, pair.Value, 0));
                }
            }


        }

        public double GetTotalPercent()
        {
            int totalOrder = 0;
            int totalUsed = 0;
            foreach (var line in _comparisonLines)
            {
                totalOrder += line.GetOrdered();
                totalUsed += line.GetUsed();
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
