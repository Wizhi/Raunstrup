using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Domain
{
    public class ProjectComparison
    {
        private Project project;
        private List<ProjectComparisonLine> comparisonLines = new List<ProjectComparisonLine>(); 
        public ProjectComparison(Project project, List<Report> reports)
        {
            this.project = project;
            CompareProject(reports);
        }

        private void CompareProject(List<Report> reports)
        {
            //Create dictionary which maps items to the amount of them in the order
            //This is neccesary because there can be multiple orderlines with them same item
            List<OrderLine> orderLines = project.GetDraft().GetOrderLines();
            Dictionary<LineItem,int> amountsInOrderlines = new Dictionary<LineItem, int>();
            foreach (var line in orderLines)
            {
                if (amountsInOrderlines.ContainsKey(line.getLineItem()))
                {
                    amountsInOrderlines[line.getLineItem()] += line.getQuantity();
                }
                else
                {
                    amountsInOrderlines.Add(line.getLineItem(), line.getQuantity()); 
                }
            }
            //Do the same for the report lines
            Dictionary<LineItem,int> amountsInReportLines = new Dictionary<LineItem, int>();
            foreach (var report in reports)
            {
                foreach (var line in report.getLines())
                {
                    if (amountsInReportLines.ContainsKey(line.getLineItem()))
                    {
                        amountsInReportLines[line.getLineItem()] += line.getQuantity();
                    }
                    else
                    {
                        amountsInReportLines.Add(line.getLineItem(), line.getQuantity());
                    }
                }
            }
            //Add the statistic lines
            foreach (var pair in amountsInOrderlines)
            {
                if (amountsInReportLines.ContainsKey(pair.Key))
                {
                    comparisonLines.Add(new ProjectComparisonLine(pair.Key,pair.Value,amountsInReportLines[pair.Key]));
                }
                else
                {
                    comparisonLines.Add(new ProjectComparisonLine(pair.Key, pair.Value, 0));
                }
            }


        }

        public void print()
        {
            // Print Lines
            foreach (var line in comparisonLines)
            {
                line.printLine();
            }
            //Print total
            int totalOrder = 0;
            int totalUsed = 0;
            foreach (var line in comparisonLines)
            {
                totalOrder += line.getOrdered();
                totalUsed += line.getUsed();
            }
            Console.WriteLine("Total " + " : " + totalOrder + " : " + totalUsed + " : " + ((Convert.ToDouble(totalUsed) / Convert.ToDouble(totalOrder)) * 100) + "%");
        }
    }

    public class ProjectComparisonLine
    {
        private LineItem item;
        private int amountOrdered;
        private int amountUsed;

        public ProjectComparisonLine(LineItem item, int amountOrdered, int amountUsed)
        {
            this.item = item;
            this.amountOrdered = amountOrdered;
            this.amountUsed = amountUsed;
        }

        public double calculatePercentage()
        {
            return (Convert.ToDouble(amountUsed) / Convert.ToDouble(amountOrdered)) * 100;
        }

        public void printLine()
        {
            Console.WriteLine(item.getName() + " : " + amountOrdered + " : " + amountUsed + " : " + calculatePercentage() + "%");
        }

        public int getOrdered()
        {
            return amountOrdered;
        }

        public int getUsed()
        {
            return amountUsed;
        }
    }
}
