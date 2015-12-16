using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class ProductCRUDForm : Form
    {
        private ProductCRUDController _productController;
        private bool _editMode;
        public ProductCRUDForm(Company company)
        {
            InitializeComponent();
            _productPriceNumericUpDown.Maximum = decimal.MaxValue;
            _costPriceNumericUpDown.Maximum = decimal.MaxValue;
            _editMode = false;
            _productController = company.CreateProductController();
            _materialRadioButton.Checked = true;
        }

        public ProductCRUDForm(Company company, ReadOnlyProduct product)
        {
            InitializeComponent();
            _productPriceNumericUpDown.Maximum = decimal.MaxValue;
            _costPriceNumericUpDown.Maximum = decimal.MaxValue;
            _productNameTextBox.Text = product.Name;
            _productPriceNumericUpDown.Value = product.SalesPrice;
            if (product is ReadOnlyMaterial)
            {
                _materialRadioButton.Checked = true;
                _costPriceNumericUpDown.Value = ((ReadOnlyMaterial)product).CostPrice;
            }
            else if (product is ReadOnlyWorkHour)
            {
                _workHourRadioButton.Checked = true;
                _costPriceNumericUpDown.Visible = false;
                _costPriceLabel.Visible = false;
            }
            else if (product is ReadOnlyTransport)
            {
                _transportRadioButton.Checked = true;
                _costPriceNumericUpDown.Visible = false;
                _costPriceLabel.Visible = false;
            }
            _materialRadioButton.Enabled = false;
            _workHourRadioButton.Enabled = false;
            _transportRadioButton.Enabled = false;
            _editMode = true;

            _productController = company.CreateProductController();
            _productController.EditProduct(product.ID);
        }

        private void _saveProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editMode)
                {
                    _productController.SetName(_productNameTextBox.Text);
                    _productController.SetPrice(_productPriceNumericUpDown.Value);
                    if (_materialRadioButton.Checked)
                    {
                        _productController.SetCostPrice(_costPriceNumericUpDown.Value);
                    }
                    _productController.SaveProduct();
                }
                else if (!_editMode)
                {
                    if (_materialRadioButton.Checked)
                    {
                        _productController.CreateNewProduct(ProductCRUDController.ProductType.Material);
                        _productController.SetCostPrice(_costPriceNumericUpDown.Value);
                    }
                    else if (_workHourRadioButton.Checked)
                    {
                        _productController.CreateNewProduct(ProductCRUDController.ProductType.WorkHour);
                    }
                    else if (_transportRadioButton.Checked)
                    {
                        _productController.CreateNewProduct(ProductCRUDController.ProductType.Transport);
                    }
                    _productController.SetName(_productNameTextBox.Text);
                    _productController.SetPrice(_productPriceNumericUpDown.Value);
                    _productController.SaveProduct();
                }
                MessageBox.Show(@"Varen blev gemt.");
                Close();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        private void _materialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_materialRadioButton.Checked)
            {
                MoveDown();
            }
            else if (!_materialRadioButton.Checked)
            {
                MoveUp();
            }

        }

        private void MoveDown()
        {
            Height += 28;
            _transportRadioButton.Location = new Point(_transportRadioButton.Location.X, _transportRadioButton.Location.Y + 28);
            _workHourRadioButton.Location = new Point(_workHourRadioButton.Location.X, _workHourRadioButton.Location.Y + 28);
            _materialRadioButton.Location = new Point(_materialRadioButton.Location.X, _materialRadioButton.Location.Y + 28);
            _saveProductButton.Location = new Point(_saveProductButton.Location.X, _saveProductButton.Location.Y + 28);
            _costPriceLabel.Visible = true;
            _costPriceNumericUpDown.Enabled = true;
            _costPriceNumericUpDown.Visible = true;
        }

        private void MoveUp()
        {
            _costPriceLabel.Visible = false;
            _costPriceNumericUpDown.Enabled = false;
            _costPriceNumericUpDown.Visible = false;
            Height -= 28;
            _saveProductButton.Location = new Point(_saveProductButton.Location.X, _saveProductButton.Location.Y - 28);
            _materialRadioButton.Location = new Point(_materialRadioButton.Location.X, _materialRadioButton.Location.Y - 28);
            _workHourRadioButton.Location = new Point(_workHourRadioButton.Location.X, _workHourRadioButton.Location.Y - 28);
            _transportRadioButton.Location = new Point(_transportRadioButton.Location.X, _transportRadioButton.Location.Y - 28);
        }
    }
}
