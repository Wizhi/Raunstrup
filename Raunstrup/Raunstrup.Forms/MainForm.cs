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

        private void _openDraftButton_Click(object sender, EventArgs e)
        {
            ReadOnlyDraft draft = null;

            if (_draftOLV.SelectedIndex > -1)
            {
                draft = (ReadOnlyDraft) _draftOLV.SelectedObject;
            }
            else if (_projectOLV.SelectedIndex > -1)
            {
                draft = ((ReadOnlyProject) _projectOLV.SelectedObject).Draft;
            }
            
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

        private void kundekatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerSelectForm = new CustomerSelectForm(_company);
            customerSelectForm.ShowDialog();
        }

        private void ansatteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var employeeSelectForm = new EmployeeCRUDForm(_company);
            employeeSelectForm.ShowDialog();
        }

        private void _projectOLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recursion is fun.
            if (_projectOLV.SelectedIndex != -1)
            {
                _draftOLV.SelectedIndex = -1;
            }
        }

        private void _draftOLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recursion is fun.
            if (_draftOLV.SelectedIndex != -1)
            {
                _projectOLV.SelectedIndex = -1;
            }
        }

        private void ansatteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new EmployeeStatisticsForm(_company).Show();
        }

        private void varerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productSelectForm = new ProductSelectForm(_company);
            productSelectForm.ShowDialog();
        }

        private void indlæsRapportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "Rapport XML (*.xml)|*.xml";

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // TODO: Implement a better way of handling reading the report.
                _company.CreateReportController().ReadReport(dialog.FileName);

                // TODO: Handle report not actually being inserted.
                MessageBox.Show("Rapport blev indlæst.");
            }
        }

        private void _helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"Help\MainForm.pdf");
        }
    }
}
