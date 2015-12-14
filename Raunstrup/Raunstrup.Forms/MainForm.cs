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
    public partial class MainForm : Form
    {

        private DraftController _draftController;
        private Company _company;
        public MainForm(Company company)
        {
            InitializeComponent();
            _company = company;
            _draftController = company.CreateDraftController();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateOLVs();
        }

        private void _openProjectDraftButton_Click(object sender, EventArgs e)
        {
            var project = (ReadOnlyProject) _projectOLV.SelectedObject;
            if (project != null)
            {
                var draftForm = new DraftCreateForm(_company, project.Draft);
                draftForm.ShowDialog();
                UpdateOLVs();
            }
        }

        private void _openDraftButton_Click(object sender, EventArgs e)
        {
            var draft = (ReadOnlyDraft) _draftOLV.SelectedObject;
            if (draft != null)
            {
                var draftForm = new DraftCreateForm(_company, draft);
                draftForm.ShowDialog();
                UpdateOLVs();
            }
        }

        private void _createDraftButton_Click(object sender, EventArgs e)
        {
            var draftForm = new DraftCreateForm(_company);
            draftForm.ShowDialog();
            UpdateOLVs();
        }

        private void UpdateOLVs()
        {
            _projectOLV.SetObjects(_draftController.GetAllProjects());
            _draftOLV.SetObjects(_draftController.GetDraftsWitihoutProject());
            _projectOLV.Refresh();
            _draftOLV.Refresh();
        }


    }
}
