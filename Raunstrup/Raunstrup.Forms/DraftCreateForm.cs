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
            _employeeComboBox.DataSource = _draftController.GetAllEmployees();
            _employeeComboBox.DisplayMember = "Name";
            _productOLV.SetObjects(_draftController.GetAllProducts());
            
        }

        private void _saveDraftButton_Click(object sender, EventArgs e)
        {

            var readOnlyCustomer = _customerComboBox.SelectedItem as ReadOnlyCustomer;
            var readOnlyEmployee = _employeeComboBox.SelectedItem as ReadOnlyEmployee;
            if (readOnlyCustomer != null)
            {
                _draftController.CreateNewDraft(readOnlyCustomer.Id);
            }
            else
            {
                MessageBox.Show(@"Vælg venligst en kunde.");
            }
            if (readOnlyEmployee != null)
            {
                _draftController.SetResponsibleEmployee(readOnlyEmployee.Id);
            }
            else
            {
                MessageBox.Show(@"Vælg venligst en ansvarshavende.");
            }
            _draftController.SetDescription(_draftDescriptionTextBox.Text);
            _draftController.SetStartDate(_startDateDateTimePicker.Value);
            _draftController.SetEndDate(_endDateDateTimePicker.Value);
            _draftController.SetTitle(_draftTitleTextBox.Text);
            
        }

        private void _addToDraftOrderLineOLV_Click(object sender, EventArgs e)
        {
            //_draftController.AddOrderLine();
            //_draftOrderLineOLV.AddObject(new ReadOnlyOrderLine());
        }
    }
}
