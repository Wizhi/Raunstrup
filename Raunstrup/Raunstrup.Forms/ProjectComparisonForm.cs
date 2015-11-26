using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raunstrup.Core.Controllers;
using Raunstrup.Core.statistics;

namespace Raunstrup.Forms
{
    public partial class ProjectComparisonForm : Form
    {
        public ProjectComparisonForm(ReportController reportController, int projectId)
        {
            InitializeComponent();
            bindComparisonToListBox(reportController.GetProjectComparison(projectId));
            bindComparsionToProgressBar(reportController.GetProjectComparison(projectId));
            bindComparsionToPercentLabel(reportController.GetProjectComparison(projectId));
        }

        private void bindComparisonToListBox(ProjectComparison comparison)
        {
            foreach (var line in comparison.GetComparisonLines())
            {
                ComparisonListBox.Items.Add(line.GetProductName() + ": " + line.AmountUsed + " brugt af " + line.AmountOrdered + " = " + line.CalculatePercentage() + "%");
            }
        }

        private void bindComparsionToProgressBar(ProjectComparison comparison)
        {
            int value = Convert.ToInt32(comparison.GetTotalPercent());
            if (value > 100)
            {
                value = 100;
            }
            ProjectProgressBar.Value = value;
        }

        private void bindComparsionToPercentLabel(ProjectComparison comparison)
        {
            int value = Convert.ToInt32(comparison.GetTotalPercent());
            label3.Text = value + "%";
        }
    }
}
