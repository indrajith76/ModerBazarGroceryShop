﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;
        private readonly CategoryRepository _categoryRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ProductRepository productRepository, 
            CategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<ViewResult> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts();
            return View(data);
        }

        public async Task<ViewResult> GetProduct(int id)
        {
            var data = await _productRepository.GetProductById(id);
            return View(data);
        }
        public List<ProductModel> SearchProduct(string productName, string brandName)
        {
            return _productRepository.SearchProduct(productName, brandName);
        }
        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel();

            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllCategories(), "CategoryID", "CategoryName");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (productModel.ProductImage != null)
                {
                    string folder = "image/ProductImg/";
                    folder += Guid.NewGuid().ToString() +"_"+ productModel.ProductImage.FileName;

                    productModel.Image = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await productModel.ProductImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                int id = await _productRepository.AddNewProduct(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
                }
            }
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllCategories(), "CategoryID", "CategoryName");

            return View();
        }

        //Actions for Admin Panel
        public async Task<ViewResult> AllProductsData()
        {
            var data = await _productRepository.GetAllProducts();
            return View(data);
        }

        public async Task<ViewResult> EditProduct(int id)
        {
            var data = await _productRepository.EditProductById(id);
            return View(data);
        }

        public ViewResult SaveEditProduct(bool isSuccess = false, int productId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public IActionResult SaveEditProduct(ProductModel productModel)
        {
            _productRepository.EditProducts(productModel);
            return RedirectToAction(nameof(AllProductsData));
        }

        public async Task<IActionResult> DeleteProduct(int productId = 0)
        {
            await _productRepository.DeleteProductById(productId);
            return RedirectToAction(nameof(AllProductsData));
        }
    }
}
