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
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult GetAllProducts()
        {
            var data = _productRepository.GetAllProducts();
            return View(data);
        }

        public ViewResult GetProduct(int id)
        {
            var data = _productRepository.GetProductById(id);
            return View(data);
        }
        public List<ProductModel> SearchProduct(string productName, string brandName)
        {
            return _productRepository.SearchProduct(productName, brandName);
        }
        public ViewResult AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductModel productModel)
        {
            int id = _productRepository.AddNewProduct(productModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id});
            }
            return View();
        }
    }
}
