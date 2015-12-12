using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class EmployeeCRUDForm : Form
    {
        private Company _company;
        private readonly EmployeeCRUDController _employeeCRUDController;
        
        public EmployeeCRUDForm(Company company)
        {
            InitializeComponent();
            _company = company;
            _employeeCRUDController = company.CreateEmployeeCRUDController();
        }

        private void EmployeeCRUDForm_Load(object sender, EventArgs e)
        {
            _skillOLV.SetObjects(_employeeCRUDController.GetAllSkills());
            var employees = _employeeCRUDController.GetAllEmployees();
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _employeeComboBox.SelectedItem = null;
            _addEmployeeToSkillLVButton.Enabled = false;
            _createNewEmployeeRadioButton.Checked = true;
        }

        

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _skillOLV.ModelFilter = TextMatchFilter.Contains(_skillOLV, _filterTextBox.Text);
            _skillOLV.Refresh();
        }

        private void _createNewEmployeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_createNewEmployeeRadioButton.Checked)
            {
                _employeeSkillsLV.Items.Clear();
                _employeeComboBox.SelectedItem = null;
                _employeeComboBox.Enabled = false;
                _employeeCRUDController.CreateNewEmployee();
                _employeeNameTextBox.Text = "";
                _addEmployeeToSkillLVButton.Enabled = true;
            }
        }

        private void _editEmployeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_editEmployeeRadioButton.Checked)
            {
                _employeeSkillsLV.Items.Clear();
                _employeeComboBox.Enabled = true;
                _addEmployeeToSkillLVButton.Enabled = false;
                var employees = _employeeCRUDController.GetAllEmployees();
                _employeeComboBox.DataSource = employees;
                _employeeComboBox.DisplayMember = "Name";
                _employeeComboBox.SelectedItem = null;
                _employeeNameTextBox.Text = "";
            }
        }

        private void _addEmployeeSkillLV_Click(object sender, EventArgs e)
        {
            var readOnlySkill = _skillOLV.SelectedObject as ReadOnlySkill;
            if (readOnlySkill != null)
            {
                _employeeSkillsLV.Items.Add(new ListViewItem(new[]
                {
                    readOnlySkill.Name
                }) {Tag = readOnlySkill.Id});
                _employeeCRUDController.AddSkill(readOnlySkill.Id);
            }
        }

        private void _removeFromEmployeeSkillLV_Click(object sender, EventArgs e)
        {
            if (_employeeSkillsLV.FocusedItem != null)
            {
                _employeeCRUDController.RemoveSkill((int) _employeeSkillsLV.FocusedItem.Tag);
                _employeeSkillsLV.Items.Remove(_employeeSkillsLV.FocusedItem);
            }
        }

        private void _editSkillButton_Click(object sender, EventArgs e)
        {
            var editSkillForm = new SkillSelectForm(_company);
            editSkillForm.ShowDialog();
            _skillOLV.SetObjects(_employeeCRUDController.GetAllSkills());
            _skillOLV.Refresh();
        }

        private void _employeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _employeeSkillsLV.Items.Clear();
            if (_employeeComboBox.SelectedItem != null)
            {
                _employeeCRUDController.EditEmployee(((ReadOnlyEmployee)_employeeComboBox.SelectedItem).Id);
                _employeeNameTextBox.Text = _employeeCRUDController.GetEmployee().Name;
                foreach (var readOnlySkill in _employeeCRUDController.GetEmployeeSkills())
                {
                    _employeeSkillsLV.Items.Add(new ListViewItem(new[]
                    {
                        readOnlySkill.Name
                    }) { Tag = readOnlySkill.Id });
                }
                _addEmployeeToSkillLVButton.Enabled = true;
            }
        }

        private void _saveEmployeeButton_Click(object sender, EventArgs e)
        {
            _employeeCRUDController.SetEmployeeName(_employeeNameTextBox.Text);
            _employeeCRUDController.SaveEmployee();
            var employees = _employeeCRUDController.GetAllEmployees();
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _employeeComboBox.SelectedItem = null;
            _employeeNameTextBox.Text = "";
            
        }

        private void _deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            _employeeCRUDController.DeleteEmployee();
        }

    }
}
