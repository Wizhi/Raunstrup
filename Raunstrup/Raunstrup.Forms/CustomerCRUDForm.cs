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
    public partial class CustomerCRUDForm : Form
    {
        private readonly CustomerCRUDController _customerCRUDController;
        private bool _editMode;
        public bool _changed = false;
        public CustomerCRUDForm(Company company)
        {
            InitializeComponent();
            _customerCRUDController = company.CreateCustomerCRUDController();
            _editMode = false;
        }

        public CustomerCRUDForm(Company company, ReadOnlyCustomer customer)
        {
            InitializeComponent();
            _customerCRUDController = company.CreateCustomerCRUDController();
            _customerNameTextBox.Text = customer.Name;
            _streetNameTextBox.Text = customer.StreetName;
            _streetNumberTextBox.Text = customer.StreetNumber;
            _postalCodeTextBox.Text = customer.PostalCode;
            _cityTextBox.Text = customer.City;
            _customerCRUDController.EditCustomer(customer.Id);
            _editMode = true;
        }

        private void _saveCustomerButton_Click(object sender, EventArgs e)
        {
            if (!_editMode)
            {
                _customerCRUDController.CreateNewCustomer();
            }
            _customerCRUDController.SetName(_customerNameTextBox.Text);
            _customerCRUDController.SetStreet(_streetNameTextBox.Text, _streetNumberTextBox.Text);
            _customerCRUDController.SetCity(_cityTextBox.Text, _postalCodeTextBox.Text);
            _customerCRUDController.SaveCustomer();
            _changed = true;
        }
    }
}
