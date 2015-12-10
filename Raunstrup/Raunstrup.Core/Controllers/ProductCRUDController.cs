using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;
using Raunstrup.Domain.ViewObjects;

namespace Raunstrup.Core.Controllers
{
    public class ProductCRUDController
    {
        private Product _currentProduct;
        private readonly IProductRepository _productRepository;

        public ProductCRUDController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ReadOnlyProduct GetProduct()
        {
            return new ReadOnlyProduct(_currentProduct);
        }

        public void CreateNewProduct(string product)
        {
            if (product == "Material")
            {
                _currentProduct = new Material();
            }
            else if (product == "WorkHour")
            {
                _currentProduct = new WorkHour();
            }
            else if (product == "Transport")
            {
                _currentProduct = new Transport();
            }
        }

        public void EditProduct(int id)
        {
            _currentProduct = _productRepository.Get(id);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(_currentProduct);
        }

        public void SetName(string name)
        {
            _currentProduct.Name = name;
        }

        public void SetPrice(decimal price)
        {
            _currentProduct.SalesPrice = price;
        }

        public void SaveProduct()
        {
            _productRepository.Save(_currentProduct);
        }

        public List<ReadOnlyProduct> GetAllProducts()
        {
            IList<Product> products = _productRepository.GetAll();
            List<ReadOnlyProduct> returnList = new List<ReadOnlyProduct>();
            foreach (var product in products)
            {
                returnList.Add(ReadOnlyProduct.Create(product));
            }
            return returnList;
        }
    }
}
