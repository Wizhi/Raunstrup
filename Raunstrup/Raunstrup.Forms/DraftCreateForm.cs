using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class DraftCreateForm : Form
    {
        private readonly DraftController _draftController;
        private bool _editMode;
        
        public DraftCreateForm(Company company)
        {
            InitializeComponent();
            _draftController = company.GetDraftController();
            var customers = _draftController.GetAllCustomers();
            var employees = _draftController.GetAllEmployees();
            _customerComboBox.DataSource = customers;
            _customerComboBox.DisplayMember = "Name";
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _customerComboBox.SelectedItem = null;
            _employeeComboBox.SelectedItem = null;
            _addToDraftOrderLineOLV.Enabled = false;
            _editMode = false;
        }
        public DraftCreateForm(Company company, ReadOnlyDraft draft)
        {
            InitializeComponent();
            _draftController = company.GetDraftController();
            var customers = _draftController.GetAllCustomers();
            var employees = _draftController.GetAllEmployees();
            _customerComboBox.DataSource = customers;
            _customerComboBox.DisplayMember = "Name";
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _editMode = true;

            _draftController.EditDraft(draft.Id);
            foreach (var orderLine in draft.OrderLines)
            {
                _draftProductsLV.Items.Add(
                    new ListViewItem(new[]
                    {
                        orderLine.Product.Name,
                        orderLine.UnitPrice.ToString(CultureInfo.CurrentCulture),
                        orderLine.Quantity.ToString(),
                        (orderLine.UnitPrice*orderLine.Quantity).ToString(CultureInfo.CurrentCulture)
                    }));
                _productIds.Add(orderLine.Product.ID);
            }
            _draftDescriptionTextBox.Text = draft.Description;
            _draftTitleTextBox.Text = draft.Title;
            var selectedCustomer = customers.FirstOrDefault(x => x.Id == draft.Customer.Id);
            var selectedEmployee = employees.FirstOrDefault(x => x.Id == draft.ResponsiblEmployee.Id);
            _customerComboBox.SelectedItem = selectedCustomer;
            _employeeComboBox.SelectedItem = selectedEmployee;
            _startDateDateTimePicker.Value = draft.StartDate;
            _endDateDateTimePicker.Value = draft.EndDate;
            _discountInPercentNumericUpDown.Value = (decimal) draft.DiscountPercentage;
            _customerComboBox.Enabled = false;


        }

        private void DraftCreateForm_Load(object sender, EventArgs e)
        {
            _productOLV.SetObjects(_draftController.GetAllProducts());
            _priceNumericUpDown.Maximum = decimal.MaxValue;
            _quantityNumericUpDown.Maximum = decimal.MaxValue;
            _endDateDateTimePicker.Value = _endDateDateTimePicker.Value.AddDays(1);
        }

        private void _saveDraftButton_Click(object sender, EventArgs e)
        {
            if (_editMode)
            {
                var readOnlyEmployee = _employeeComboBox.SelectedItem as ReadOnlyEmployee;
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
                _draftController.SetDiscountPercentage((double) _discountInPercentNumericUpDown.Value);
                _draftController.SaveDraft();
            }

        }
        private readonly List<int> _productIds = new List<int>();
        private void _addToDraftOrderLineOLV_Click(object sender, EventArgs e)
        {
            var readOnlyCustomer = _customerComboBox.SelectedItem as ReadOnlyCustomer;
            if (readOnlyCustomer != null)
            {
                if (!_editMode)
                {
                    _draftController.CreateNewDraft(((ReadOnlyCustomer) _customerComboBox.SelectedItem).Id);
                    _customerComboBox.Enabled = false;
                    _editMode = true;
                }
            }
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
                _draftController.AddOrderLine(
                    _productIds[_productIds.Count-1],
                    Convert.ToInt32(_draftProductsLV.Items[_draftProductsLV.Items.Count - 1].SubItems[2].Text),
                    Convert.ToDecimal(_draftProductsLV.Items[_draftProductsLV.Items.Count - 1].SubItems[1].Text)
                );
            }
        }

        private ListViewItem _orderLine;
        private int _draftProductsLvIndex;

        private void _draftProductsLV_MouseClick(object sender, MouseEventArgs e)
        {
            
            _orderLine = _draftProductsLV.FocusedItem;
            _draftProductsLvIndex = _draftProductsLV.FocusedItem.Index;
            _priceNumericUpDown.Value = Convert.ToDecimal(_orderLine.SubItems[1].Text);
            _quantityNumericUpDown.Value = Convert.ToDecimal(_orderLine.SubItems[2].Text);
        }

        private void _editOrderLineButton_Click(object sender, EventArgs e)
        {
            if (_draftController.GetDraft() != null)
            {
                _draftController.EditOrderline(_draftProductsLvIndex, (int)_quantityNumericUpDown.Value, _priceNumericUpDown.Value);
            }
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
            if (_draftController.GetDraft() != null)
            {
                _draftController.RemoveOrderLine(_draftProductsLvIndex);
            }
            _productIds.RemoveAt(_draftProductsLV.FocusedItem.Index);
            _draftProductsLV.Items.Remove(_draftProductsLV.FocusedItem);
        }

        private void _startDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_endDateDateTimePicker.Value <= _startDateDateTimePicker.Value)
            {
                _endDateDateTimePicker.Value = _startDateDateTimePicker.Value.AddDays(1);
            }
        }

        private void _endDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_endDateDateTimePicker.Value <= _startDateDateTimePicker.Value)
            {
                _endDateDateTimePicker.Value = _startDateDateTimePicker.Value.AddDays(1);
                MessageBox.Show(@"Slutdatoen skal være efter startdatoen.");
            }
        }

        private void _customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _addToDraftOrderLineOLV.Enabled = true;
        }

    }
}
