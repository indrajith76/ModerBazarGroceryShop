using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(CategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult> GetAllCategories()
        {
            var data = await _categoryRepository.GetAllCategories();
            return View(data);
        }

        public async Task<ViewResult> EditCategory(int id)
        {
            var data = await _categoryRepository.EditCategoryById(id);
            return View(data);
        }
        
        public ViewResult AddNewCategory(bool isSuccess = false, int categorytId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CategoryID = categorytId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryModel.CatImage != null)
                {
                    string folder = "image/CategoryImg/";
                    folder += Guid.NewGuid().ToString() + "_" + categoryModel.CatImage.FileName;

                    categoryModel.CategoryImage = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await categoryModel.CatImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                int id = _categoryRepository.AddNewCategory(categoryModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewCategory), new { isSuccess = true, categorytId = id });
                }

            }
            
            return View();
        }

        public ViewResult SaveEditCategory(bool isSuccess = false, int categorytId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CategoryID = categorytId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryModel.CatImage != null)
                {
                    string folder = "image/CategoryImg/";
                    folder += Guid.NewGuid().ToString() + "_" + categoryModel.CatImage.FileName;

                    categoryModel.CategoryImage = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await categoryModel.CatImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                await _categoryRepository.SaveEditCategoryAsync(categoryModel);

                return RedirectToAction(nameof(GetAllCategories));
            }
            return View(categoryModel);
        }

        public async Task<IActionResult> DeleteCategory(int categorytId = 0)
        {
            await _categoryRepository.DeleteCategoryById(categorytId);
            return RedirectToAction(nameof(GetAllCategories));
        }

    }
}
