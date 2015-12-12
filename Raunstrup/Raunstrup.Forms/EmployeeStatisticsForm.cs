using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Raunstrup.Core;
using Raunstrup.Core.Statistics;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class EmployeeStatisticsForm : Form
    {
        private Company _company;
        public EmployeeStatisticsForm(Company company)
        {
            InitializeComponent();
            _company = company;
            SetUpEmployeeListBox();
        }

        private void SetUpEmployeeListBox()
        {
            EmployeeBox.DataSource = _company.CreateReportController().GetAllEmployees();
            EmployeeBox.DisplayMember = "Name";
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            HoursWorkedChart.Series[0].Points.Clear();
            ReadOnlyEmployee employee = EmployeeBox.SelectedItem as ReadOnlyEmployee;
            EmployeeStatistics employeeStatistics = _company.CreateReportController().GetHoursWorkedStatistics(employee.Id,StartDatePicker.Value,EndDatePicker.Value);
            var dict = employeeStatistics.GetHoursWorkedByDay();
            foreach (var pair in dict)
            {
                HoursWorkedChart.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
            InvoicedDegreeLabel.Text = employeeStatistics.GetHoursInvoicedDegree().ToString() + "%";
        }
    }
}
