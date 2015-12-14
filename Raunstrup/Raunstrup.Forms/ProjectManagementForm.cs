using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class ProjectManagementForm : Form
    {
        private readonly ProjectController _controller;
        private readonly ReadOnlyProject _project;

        public ProjectManagementForm(ProjectController controller, int id)
        {
            InitializeComponent();

            _controller = controller;
            _project = _controller.Load(id);
        }

        private void ProjectManagementForm_Load(object sender, EventArgs e)
        {
            _employeesOLV.SetObjects(_project.Employees);
            _availableEmployeesOLV.SetObjects(_controller.GetAvailableEmployees());
        }

        private void _employeeRemoveButton_Click(object sender, EventArgs e)
        {
            var selected = _employeesOLV.SelectedObjects;

            foreach (ReadOnlyEmployee employee in _employeesOLV.SelectedObjects)
            {
                _controller.RemoveEmployee(employee.Id);
                Console.WriteLine("REMOVE {0}", employee.Name);
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
                Console.WriteLine("ADD {0}", employee.Name);
            }

            _availableEmployeesOLV.RemoveObjects(selected);
            _employeesOLV.AddObjects(selected);
        }

        private void _employeesOLV_SelectionChanged(object sender, EventArgs e)
        {
            _employeeRemoveButton.Enabled = _employeesOLV.SelectedIndices.Count > 0;
        }

        private void _availableEmployeesOLV_SelectionChanged(object sender, EventArgs e)
        {
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
    }
}
