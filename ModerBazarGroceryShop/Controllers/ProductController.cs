using Microsoft.AspNetCore.Mvc;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public ProductModel GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public List<ProductModel> SearchProduct(string productName, string brandName)
        {
            return _productRepository.SearchProduct(productName, brandName);
        }
    }
}
