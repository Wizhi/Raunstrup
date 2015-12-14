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

namespace Raunstrup.Forms
{
    public partial class CustomerSelectForm : Form
    {
        private Company _company;
        private CustomerCRUDController _customerCRUDController;
        public CustomerSelectForm(Company company)
        {
            InitializeComponent();
            _company = company;
            _customerCRUDController = company.CreateCustomerCRUDController();
        }

        private void CustomerSelectForm_Load(object sender, EventArgs e)
        {
            foreach (var readOnlyCustomer in _customerCRUDController.GetAllCustomers())
            {
                _customerListView.Items.Add(new ListViewItem(new[]
                {
                    readOnlyCustomer.Id.ToString(),
                    readOnlyCustomer.Name,
                    readOnlyCustomer.PostalCode
                }) { Tag = readOnlyCustomer.Id });
            }
        }

        private void _deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (_customerListView.FocusedItem != null)
            {
                _customerCRUDController.EditCustomer((int) _customerListView.FocusedItem.Tag);
                _customerCRUDController.DeleteCustomer();
            }
        }

        private void _createNewCustomerButton_Click(object sender, EventArgs e)
        {
            var createCustomerForm = new CustomerCRUDForm(_company);
            createCustomerForm.ShowDialog();
            if (createCustomerForm._changed)
            {
                _customerListView.Items.Clear();
                foreach (var readOnlyCustomer in _customerCRUDController.GetAllCustomers())
                {
                    _customerListView.Items.Add(new ListViewItem(new[]
                    {
                        readOnlyCustomer.Id.ToString(),
                        readOnlyCustomer.Name,
                        readOnlyCustomer.PostalCode
                    }) { Tag = readOnlyCustomer.Id });
                }
            }
        }

        private void _editCustomerButton_Click(object sender, EventArgs e)
        {
            if (_customerListView.FocusedItem != null)
            {
                _customerCRUDController.EditCustomer((int)_customerListView.FocusedItem.Tag);
                var editCustomerForm = new CustomerCRUDForm(_company, _customerCRUDController.GetCustomer());
                editCustomerForm.ShowDialog();
                if (editCustomerForm._changed)
                {
                    _customerListView.Items.Clear();
                    foreach (var readOnlyCustomer in _customerCRUDController.GetAllCustomers())
                    {
                        _customerListView.Items.Add(new ListViewItem(new[]
                        {
                            readOnlyCustomer.Id.ToString(),
                            readOnlyCustomer.Name,
                            readOnlyCustomer.PostalCode
                        }) { Tag = readOnlyCustomer.Id });
                    }
                }
            }
        }
    }
}
