using System;
using System.Collections.Generic;
using System.Globalization;
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
            _priceNumericUpDown.Maximum = decimal.MaxValue;
            _quantityNumericUpDown.Maximum = decimal.MaxValue;
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

            for (int i = 0; i < _draftProductsLV.Items.Count; i++)
            {
                _draftController.AddOrderLine(
                    _productIds[i], 
                    Convert.ToInt32(_draftProductsLV.Items[i].SubItems[2].Text),
                    Convert.ToDecimal(_draftProductsLV.Items[i].SubItems[1].Text)
                );
            }
            
        }
        private readonly List<int> _productIds = new List<int>();
        private void _addToDraftOrderLineOLV_Click(object sender, EventArgs e)
        {
            var readOnlyProduct = _productOLV.SelectedObject as ReadOnlyProduct;
            if (readOnlyProduct != null)
            {
                _draftProductsLV.Items.Add(
                    new ListViewItem(new[]
                    {
                        readOnlyProduct.Name,
                        readOnlyProduct.SalesPrice.ToString(CultureInfo.CurrentCulture),
                        "1",
                        readOnlyProduct.SalesPrice.ToString(CultureInfo.CurrentCulture),
                    }));
                _productIds.Add(readOnlyProduct.ID);
            }
        }

        private ListViewItem _orderLine;
        private int _draftProductsLvIndex;

        private void _draftProductsLV_MouseClick(object sender, MouseEventArgs e)
        {
            
            _orderLine = _draftProductsLV.FocusedItem;
            _draftProductsLvIndex = _draftProductsLV.FocusedItem.Index;
            Console.WriteLine(_draftProductsLV.FocusedItem.Index);
            _priceNumericUpDown.Value = Convert.ToDecimal(_orderLine.SubItems[1].Text);
            _quantityNumericUpDown.Value = Convert.ToDecimal(_orderLine.SubItems[2].Text);
        }

        private void _editOrderLineButton_Click(object sender, EventArgs e)
        {
            _draftProductsLV.Items[_draftProductsLvIndex] = new ListViewItem(
                new[]
                {
                    _orderLine.SubItems[0].Text, 
                    _priceNumericUpDown.Value.ToString(CultureInfo.CurrentCulture), 
                    _quantityNumericUpDown.Value.ToString(CultureInfo.CurrentCulture), 
                    (_priceNumericUpDown.Value*_quantityNumericUpDown.Value).ToString(CultureInfo.CurrentCulture)
                });
        }

        private void _removeFromDraftOrderLineOLV_Click(object sender, EventArgs e)
        {
            _productIds.RemoveAt(_draftProductsLV.FocusedItem.Index);
            _draftProductsLV.Items.Remove(_draftProductsLV.FocusedItem);
        }

    }
}
