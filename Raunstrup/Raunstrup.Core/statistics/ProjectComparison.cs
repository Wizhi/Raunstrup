using System;
using System.Collections.Generic;
using Raunstrup.Core.Domain;
using Raunstrup.Core.Repos;

namespace Raunstrup.Core.statistics
{
    public class ProjectComparison
    {
        private Project _project;
        private List<ProjectComparisonLine> _comparisonLines = new List<ProjectComparisonLine>(); 
        public ProjectComparison(Project project, ReportRepo repo)
        {
            List<Report> reports = repo.GetByProject(project);
            _project = project;
            CompareProject(reports);
        }

        private void CompareProject(List<Report> reports)
        {
            //Create dictionary which maps items to the amount of them in the order
            //This is neccesary because there can be multiple orderlines with them same item
            List<OrderLine> orderLines = _project.GetDraft().GetOrderLines();
            Dictionary<LineItem,int> amountsInOrderlines = new Dictionary<LineItem, int>();
            foreach (var line in orderLines)
            {
                if (amountsInOrderlines.ContainsKey(line.GetLineItem()))
                {
                    amountsInOrderlines[line.GetLineItem()] += line.GetQuantity();
                }
                else
                {
                    amountsInOrderlines.Add(line.GetLineItem(), line.GetQuantity()); 
                }
            }
            //Do the same for the report lines
            Dictionary<LineItem,int> amountsInReportLines = new Dictionary<LineItem, int>();
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

        public void Print()
        {
            // Print Lines
            foreach (var line in _comparisonLines)
            {
                line.PrintLine();
            }
            //Print total
            Console.WriteLine(GetTotalPercent());
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
        private LineItem _item;
        private int _amountOrdered;
        private int _amountUsed;

        public ProjectComparisonLine(LineItem item, int amountOrdered, int amountUsed)
        {
            _item = item;
            _amountOrdered = amountOrdered;
            _amountUsed = amountUsed;
        }

        public double CalculatePercentage()
        {
            return (Convert.ToDouble(_amountUsed) / Convert.ToDouble(_amountOrdered)) * 100;
        }

        public void PrintLine()
        {
            Console.WriteLine(_item.GetName() + " : " + _amountOrdered + " : " + _amountUsed + " : " + CalculatePercentage() + "%");
        }

        public int GetOrdered()
        {
            return _amountOrdered;
        }

        public int GetUsed()
        {
            return _amountUsed;
        }
    }
}
