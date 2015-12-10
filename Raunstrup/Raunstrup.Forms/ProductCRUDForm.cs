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
    public partial class ProductCRUDForm : Form
    {
        private ProductCRUDController _productController;
        private bool _editMode;
        public ProductCRUDForm(Company company)
        {
            InitializeComponent();
            _productPriceNumericUpDown.Maximum = Decimal.MaxValue;
            _editMode = false;
            _productController = company.GetProductController();
        }

        public ProductCRUDForm(Company company, ReadOnlyProduct product)
        {
            InitializeComponent();
            _productPriceNumericUpDown.Maximum = Decimal.MaxValue;
            _productNameTextBox.Text = product.Name;
            _productPriceNumericUpDown.Value = product.SalesPrice;
            if (product is ReadOnlyMaterial)
            {
                _materialRadioButton.Checked = true;
            }
            else if (product is ReadOnlyWorkHour)
            {
                _workHourRadioButton.Checked = true;
            }
            else if (product is ReadOnlyTransport)
            {
                _transportRadioButton.Checked = true;
            }
            _materialRadioButton.Enabled = false;
            _workHourRadioButton.Enabled = false;
            _transportRadioButton.Enabled = false;
            _editMode = true;
            _productController = company.GetProductController();
            _productController.EditProduct(product.ID);
        }

        private void _saveProductButton_Click(object sender, EventArgs e)
        {
            if (_editMode)
            {
                _productController.SetName(_productNameTextBox.Text);
                _productController.SetPrice(_productPriceNumericUpDown.Value);
                _productController.SaveProduct();
            }
            else if (!_editMode)
            {
                if (_materialRadioButton.Checked)
                {
                    _productController.CreateNewProduct("Material");
                }
                else if (_workHourRadioButton.Checked)
                {
                    _productController.CreateNewProduct("WorkHour");
                }
                else if (_transportRadioButton.Checked)
                {
                    _productController.CreateNewProduct("Transport");
                }
                _productController.SetName(_productNameTextBox.Text);
                _productController.SetPrice(_productPriceNumericUpDown.Value);
                _productController.SaveProduct();
            
            }
        }
    }
}
