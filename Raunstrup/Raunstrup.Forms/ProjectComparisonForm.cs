using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Core.Statistics;

namespace Raunstrup.Forms
{
    public partial class ProjectComparisonForm : Form
    {
        private Company _company;
        private ReportController _reportController;
        public ProjectComparisonForm(Company company, int projectId)
        {
            InitializeComponent();
            _reportController = company.CreateReportController();
            bindComparisonToListBox(_reportController.GetProjectComparison(projectId));
            bindComparsionToProgressBar(_reportController.GetProjectComparison(projectId));
            bindComparsionToPercentLabel(_reportController.GetProjectComparison(projectId));
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
