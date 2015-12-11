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
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class SkillCRUDForm : Form
    {
        private EmployeeCRUDController _employeeCRUDController;
        public SkillCRUDForm(Company company)
        {
            InitializeComponent();
            _employeeCRUDController = company.GetEmployeeCRUDController();
            _employeeCRUDController.CreateNewSkill();
        }

        public SkillCRUDForm(Company company, ReadOnlySkill skill)
        {
            InitializeComponent();
            _employeeCRUDController = company.GetEmployeeCRUDController();
            _employeeCRUDController.EditSkill(skill.Id);
            _skillNameTextBox.Text = skill.Name;
        }

        private void _saveSkillButton_Click(object sender, EventArgs e)
        {
            _employeeCRUDController.SetSkillName(_skillNameTextBox.Text);
            _employeeCRUDController.SaveSkill();
            MessageBox.Show(@"Specialet blev gemt.");
            Close();
        }
    }
}
