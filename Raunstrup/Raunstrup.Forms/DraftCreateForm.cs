using System;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;


namespace Raunstrup.Forms
{
    public partial class DraftCreateForm : Form
    {
        private readonly Company _company = new Company();
        private readonly DraftController _draftController;

        
        
        public DraftCreateForm()
        {
            InitializeComponent();
            _draftController = _company.GetDraftController();
        }

        private void DraftCreateForm_Load(object sender, EventArgs e)
        {

            _customerComboBox.DataSource = _draftController.GetAllCustomers();
            _customerComboBox.DisplayMember = "Name";
            _productOLV.SetObjects(_draftController.GetAllProducts());
            
        }

        private void _saveDraftButton_Click(object sender, EventArgs e)
        {

            var readOnlyCustomer = _customerComboBox.SelectedItem as ReadOnlyCustomer;
            if (readOnlyCustomer != null)
            {
                _draftController.CreateNewDraft(readOnlyCustomer.Id);
            }
            else
            {
                MessageBox.Show(@"Vælg venligst en kunde.");
            }
        }
    }
}
