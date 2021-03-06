﻿using System;
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

        //Adds all the comparison lines to the ListBox
        private void bindComparisonToListBox(ProjectComparison comparison)
        {
            foreach (var line in comparison.GetComparisonLines())
            {
                ComparisonListBox.Items.Add(line.GetProductName() + ": " + line.AmountUsed + " brugt af " + line.AmountOrdered + " = " + string.Format("{0:0.##}", line.CalculatePercentage()) + "%");
            }
        }

        //Adds the total completion percent to the progress bar
        private void bindComparsionToProgressBar(ProjectComparison comparison)
        {
            int value = Convert.ToInt32(comparison.GetTotalPercent());
            if (value > 100)
            {
                value = 100;
            }
            ProjectProgressBar.Value = value;
        }

        //Adds the total completion percent to the label
        private void bindComparsionToPercentLabel(ProjectComparison comparison)
        {
            int value = Convert.ToInt32(comparison.GetTotalPercent());
            label3.Text = value + "%";
        }
    }
}
