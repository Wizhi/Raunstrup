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
            return ReadOnlyProduct.Create(_currentProduct);
        }

        public enum ProductType
        {
            Material,
            WorkHour,
            Transport
        }

        public void CreateNewProduct(ProductType type)
        {
            if (type == ProductType.Material)
            {
                _currentProduct = new Material();
            }
            else if (type == ProductType.WorkHour)
            {
                _currentProduct = new WorkHour();
            }
            else if (type == ProductType.Transport)
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

        public void SetCostPrice(decimal price)
        {
            var product = _currentProduct as Material;
            if (product != null)
            {
                product.CostPrice = price;
            }
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
