using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raunstrup.Core;
using Raunstrup.Core.Controllers;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Forms
{
    public partial class ProductSelectForm : Form
    {
        private Company _company;
        private readonly ProductCRUDController _productController;
        public ProductSelectForm(Company company)
        {
            InitializeComponent();
            _productController = company.CreateProductController();
            _company = company;
            foreach (var readOnlyProduct in _productController.GetAllProducts())
            {
                var temp = new ListViewItem(new[]
                {
                    readOnlyProduct.Name,
                    readOnlyProduct.SalesPrice.ToString("C")
                    
                });
                temp.Tag = readOnlyProduct.ID;
                _productListView.Items.Add(temp);
                if (readOnlyProduct is ReadOnlyMaterial)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[0];
                }
                else if (readOnlyProduct is ReadOnlyWorkHour)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[1];
                }
                else if (readOnlyProduct is ReadOnlyTransport)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[2];
                }
            }
        }

        private void _editProductButton_Click(object sender, EventArgs e)
        {
            _productController.EditProduct((int)_productListView.FocusedItem.Tag);
            var editForm = new ProductCRUDForm(_company, _productController.GetProduct());
            editForm.ShowDialog();
            _productListView.Items.Clear();
            foreach (var readOnlyProduct in _productController.GetAllProducts())
            {
                var temp = new ListViewItem(new[]
                {
                    readOnlyProduct.Name,
                    readOnlyProduct.SalesPrice.ToString("C")
                    
                });
                temp.Tag = readOnlyProduct.ID;
                _productListView.Items.Add(temp);
                if (readOnlyProduct is ReadOnlyMaterial)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[0];
                }
                else if (readOnlyProduct is ReadOnlyWorkHour)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[1];
                }
                else if (readOnlyProduct is ReadOnlyTransport)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[2];
                }
            }
        }

        private void _createNewProductButton_Click(object sender, EventArgs e)
        {
            var createForm = new ProductCRUDForm(_company);
            createForm.ShowDialog();
            _productListView.Items.Clear();
            foreach (var readOnlyProduct in _productController.GetAllProducts())
            {
                var temp = new ListViewItem(new[]
                {
                    readOnlyProduct.Name,
                    readOnlyProduct.SalesPrice.ToString("C")
                    
                });
                temp.Tag = readOnlyProduct.ID;
                _productListView.Items.Add(temp);
                if (readOnlyProduct is ReadOnlyMaterial)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[0];
                }
                else if (readOnlyProduct is ReadOnlyWorkHour)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[1];
                }
                else if (readOnlyProduct is ReadOnlyTransport)
                {
                    _productListView.Items[_productListView.Items.IndexOf(temp)].Group = _productListView.Groups[2];
                }
            }
        }

        private void _deleteProductButton_Click(object sender, EventArgs e)
        {
            _productController.DeleteProduct((int)_productListView.FocusedItem.Tag);
            _productListView.Items.Remove(_productListView.FocusedItem);
        }

        private void _helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"Help/ProductSelectForm.pdf");
        }
    }
}
