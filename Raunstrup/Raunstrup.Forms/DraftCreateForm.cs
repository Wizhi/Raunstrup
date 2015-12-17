using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class DraftCreateForm : Form
    {
        private readonly DraftController _draftController;
        private Company _company;
        private bool _editMode;
        
        public DraftCreateForm(Company company)
        {
            InitializeComponent();
            _company = company;
            _draftController = company.CreateDraftController();
            var customers = _draftController.GetAllCustomers();
            var employees = _draftController.GetAllEmployees();
            _customerComboBox.DataSource = customers;
            _customerComboBox.DisplayMember = "Name";
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _customerComboBox.SelectedIndex = -1;
            _employeeComboBox.SelectedItem = null;
            _offerRadioButton.Checked = true;
            _editMode = false;
        }
        public DraftCreateForm(Company company, ReadOnlyDraft draft)
        {
            InitializeComponent();
            _company = company;
            _draftController = company.CreateDraftController();
            var customers = _draftController.GetAllCustomers();
            var employees = _draftController.GetAllEmployees();
            _customerComboBox.DataSource = customers;
            _customerComboBox.DisplayMember = "Name";
            _employeeComboBox.DataSource = employees;
            _employeeComboBox.DisplayMember = "Name";
            _editMode = true;
            _draftGroupBox.Text = string.Format("Kladde #{0}",draft.Id);

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
            if (_draftController.IsPartOfProject())
            {
                _openProjectButton.Enabled = true;
            }
            else if (!_draftController.IsPartOfProject())
            {
                _makeProjectButton.Enabled = true;
            }
            if (_draftController.IsEstimate())
            {
                _estimateRadioButton.Checked = true;
            }
            else if (!_draftController.IsEstimate())
            {
                _offerRadioButton.Checked = true;
            }
            _draftDescriptionTextBox.Text = draft.Description;
            _draftTitleTextBox.Text = draft.Title;
            var selectedCustomer = customers.FirstOrDefault(x => x.Id == draft.Customer.Id);
            var selectedEmployee = employees.FirstOrDefault(x => x.Id == draft.ResponsiblEmployee.Id);
            _customerComboBox.SelectedItem = selectedCustomer;
            _employeeComboBox.SelectedItem = selectedEmployee;
            // TODO: Find a better way to do this since WinForms sucks
            //Subtracts 5 minutes form the endDate to actually get the correct date (00:00 clock makes it mess it)
            _endDateDateTimePicker.Value = draft.EndDate.Subtract(TimeSpan.FromMinutes(5));
            _startDateDateTimePicker.Value = draft.StartDate;
            _discountInPercentNumericUpDown.Value = (decimal) draft.DiscountPercentage;
            _customerComboBox.Enabled = false;


        }

        private void DraftCreateForm_Load(object sender, EventArgs e)
        {
            var productTypeColumn = new OLVColumn()
            {
                Name = "TypeSort",
                Groupable = true,
                IsVisible = false,
                Searchable = false,
                GroupKeyGetter = delegate(object value)
                {
                    return value.GetType();
                },
                GroupKeyToTitleConverter = delegate(object key)
                {


                    if (((Type)key).FullName == (typeof (ReadOnlyMaterial)).FullName)
                    {
                        return "Materiale";
                    }
                    else if (((Type)key).FullName == (typeof(ReadOnlyWorkHour)).FullName)
                    {
                        return "Arbejdstime";
                    }
                    else if (((Type)key).FullName == (typeof(ReadOnlyTransport)).FullName)
                    {
                        return "Transport";
                    }
                    else
                    {
                        return "Hvad fanden er der her";
                    }
                }

            };

            _productOLV.AllColumns.Add(productTypeColumn);
            _productOLV.RebuildColumns();
            _productOLV.SetObjects(_draftController.GetAllProducts());
            _productOLV.BuildGroups(productTypeColumn, SortOrder.None);
            _productOLV.UseFiltering = true;

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
                _draftController.SetEndDate(_endDateDateTimePicker.Value);
                _draftController.SetStartDate(_startDateDateTimePicker.Value);
                _draftController.SetTitle(_draftTitleTextBox.Text);
                _draftController.SetDiscountPercentage((double) _discountInPercentNumericUpDown.Value);
                if (_estimateRadioButton.Checked)
                {
                    _draftController.SetAsEstimate();
                }
                else if (_offerRadioButton.Checked)
                {
                    _draftController.SetAsOffer();
                }
                _draftController.SaveDraft();
                _makeProjectButton.Enabled = true;
                MessageBox.Show(@"Ordren blev gemt.");
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
            _addToDraftOrderLineOLV.Enabled = _customerComboBox.SelectedIndex > -1;
            _estimateRadioButton.Enabled = _customerComboBox.SelectedIndex > -1;
            _offerRadioButton.Enabled = _customerComboBox.SelectedIndex > -1;
            _removeFromDraftOrderLineOLV.Enabled = _customerComboBox.SelectedIndex > -1;
            _draftTitleTextBox.Enabled = _customerComboBox.SelectedIndex > -1;
            _startDateDateTimePicker.Enabled = _customerComboBox.SelectedIndex > -1;
            _endDateDateTimePicker.Enabled = _customerComboBox.SelectedIndex > -1;
            _draftDescriptionTextBox.Enabled = _customerComboBox.SelectedIndex > -1;
            _discountInPercentNumericUpDown.Enabled = _customerComboBox.SelectedIndex > -1;
            _employeeComboBox.Enabled = _customerComboBox.SelectedIndex > -1;
            _editOrderLineButton.Enabled = _customerComboBox.SelectedIndex > -1;
            _quantityNumericUpDown.Enabled = _customerComboBox.SelectedIndex > -1;
            _priceNumericUpDown.Enabled = _customerComboBox.SelectedIndex > -1;
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _productOLV.ModelFilter = TextMatchFilter.Contains(_productOLV, _filterTextBox.Text);
            _productOLV.Refresh();
        }

        private void _estimateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_estimateRadioButton.Checked)
            {
                _addToDraftOrderLineOLV.Enabled = false;
                _removeFromDraftOrderLineOLV.Enabled = false;
                _editOrderLineButton.Enabled = false;
            }
        }

        private void _offerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_offerRadioButton.Checked)
            {
                _addToDraftOrderLineOLV.Enabled = _customerComboBox.SelectedIndex > -1;
                _removeFromDraftOrderLineOLV.Enabled = _customerComboBox.SelectedIndex > -1;
                _editOrderLineButton.Enabled = _customerComboBox.SelectedIndex > -1;
            }
        }

        private void _makeProjectButton_Click(object sender, EventArgs e)
        {
            _draftController.MakeProject();
            _makeProjectButton.Enabled = false;
            _openProjectButton.Enabled = true;
        }

        private void _draftTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_draftTitleTextBox.Text != "" && !_editMode)
            {
                var readOnlyCustomer = _customerComboBox.SelectedItem as ReadOnlyCustomer;
                if (readOnlyCustomer != null)
                {
                    if (!_editMode)
                    {
                        _draftController.CreateNewDraft(((ReadOnlyCustomer)_customerComboBox.SelectedItem).Id);
                        _customerComboBox.Enabled = false;
                        _editMode = true;
                    }
                }
            }
        }

        private void _openProjectButton_Click(object sender, EventArgs e)
        {
            var projectForm = new ProjectManagementForm(_company,_draftController.GetProject().Id);
            projectForm.ShowDialog();
        }

        private void printInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _draftController.PrintInvoice();
        }
    }
}
