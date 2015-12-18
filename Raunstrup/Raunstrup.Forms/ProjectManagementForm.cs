using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class ProjectManagementForm : Form
    {
        private readonly Company _company;
        private readonly ProjectController _controller;
        private readonly ReadOnlyProject _project;

        public ProjectManagementForm(Company company, int id)
        {
            InitializeComponent();

            _company = company;
            _controller = company.CreateProjectController();
            _project = _controller.Load(id);
        }

        private void ProjectManagementForm_Load(object sender, EventArgs e)
        {
            EmployeeSkills.AspectGetter = x => string.Join(", ", ((ReadOnlyEmployee) x).Skills.Select(y => y.Name));
            AvailableEmployeeSkills.AspectGetter = x => string.Join(", ", ((ReadOnlyEmployee)x).Skills.Select(y => y.Name));

            _employeesOLV.SetObjects(_project.Employees);
            _availableEmployeesOLV.SetObjects(_controller.GetAvailableEmployees());
        }

        private void _employeeRemoveButton_Click(object sender, EventArgs e)
        {
            var selected = _employeesOLV.SelectedObjects;

            foreach (ReadOnlyEmployee employee in _employeesOLV.SelectedObjects)
            {
                _controller.RemoveEmployee(employee.Id);
            }
            
            _employeesOLV.RemoveObjects(selected);
            _availableEmployeesOLV.AddObjects(selected);
        }

        private void _employeeAddButton_Click(object sender, EventArgs e)
        {
            var selected = _availableEmployeesOLV.SelectedObjects;

            foreach (ReadOnlyEmployee employee in _availableEmployeesOLV.SelectedObjects)
            {
                _controller.AddEmployee(employee.Id);
            }

            _availableEmployeesOLV.RemoveObjects(selected);
            _employeesOLV.AddObjects(selected);
        }

        private void _employeesOLV_SelectionChanged(object sender, EventArgs e)
        {
            _availableEmployeesOLV.SelectedIndex = -1;
            _employeeRemoveButton.Enabled = _employeesOLV.SelectedIndices.Count > 0;
        }

        private void _availableEmployeesOLV_SelectionChanged(object sender, EventArgs e)
        {
            _employeesOLV.SelectedIndex = -1;
            _employeeAddButton.Enabled = _availableEmployeesOLV.SelectedIndices.Count > 0;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            _controller.Save();
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _employeesOLV.ModelFilter = TextMatchFilter.Contains(_employeesOLV, _filterTextBox.Text);
            _availableEmployeesOLV.ModelFilter = TextMatchFilter.Contains(_availableEmployeesOLV, _filterTextBox.Text);

            _employeesOLV.Refresh();
            _availableEmployeesOLV.Refresh();
        }

        private void forbrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectComparisonForm(_company, _project.Id).ShowDialog();
        }

        private void _helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"Help\ProjectManagementForm.pdf");
        }
    }
}
