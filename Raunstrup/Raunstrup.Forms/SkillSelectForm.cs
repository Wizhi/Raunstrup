using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class SkillSelectForm : Form
    {
        private Company _company;
        private readonly EmployeeCRUDController _employeeCRUDController;
        public SkillSelectForm(Company company)
        {
            InitializeComponent();
            _company = company;
            _employeeCRUDController = company.CreateEmployeeCRUDController();
        }

        private void SkillSelectForm_Load(object sender, EventArgs e)
        {
            foreach (var readOnlySkill in _employeeCRUDController.GetAllSkills())
            {
                _skillsListView.Items.Add(new ListViewItem(new[]
                {
                    readOnlySkill.Name
                }) {Tag = readOnlySkill.Id});
            }
        }

        private void _editSkillButton_Click(object sender, EventArgs e)
        {
            if (_skillsListView.FocusedItem != null)
            {
                _employeeCRUDController.EditSkill((int) _skillsListView.FocusedItem.Tag);
                var skillCRUDForm = new SkillCRUDForm(_company, _employeeCRUDController.GetSkill());
                skillCRUDForm.ShowDialog();
                _skillsListView.Items.Clear();
                foreach (var readOnlySkill in _employeeCRUDController.GetAllSkills())
                {
                    _skillsListView.Items.Add(new ListViewItem(new[]
                    {
                        readOnlySkill.Name
                    }) {Tag = readOnlySkill.Id});
                }
            }
        }

        private void _createNewSkillButton_Click(object sender, EventArgs e)
        {
            var skillCRUDForm = new SkillCRUDForm(_company);
            skillCRUDForm.ShowDialog();
            _skillsListView.Items.Clear();
            foreach (var readOnlySkill in _employeeCRUDController.GetAllSkills())
            {
                _skillsListView.Items.Add(new ListViewItem(new[]
                    {
                        readOnlySkill.Name
                    }) { Tag = readOnlySkill.Id });
            }
        }

        private void _deleteSkillButton_Click(object sender, EventArgs e)
        {
            if (_skillsListView.FocusedItem != null)
            {
                _employeeCRUDController.EditSkill((int) _skillsListView.FocusedItem.Tag);
                _employeeCRUDController.DeleteSkill();
                _skillsListView.FocusedItem = null;
            }
        }

        private void _helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"Help/SkillSelectForm.pdf");
        }
    }
}
