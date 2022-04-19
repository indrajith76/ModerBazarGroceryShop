using Microsoft.AspNetCore.Mvc;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository = null;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
        //public ViewResult GetCategoryById(int id)
        //{
        //    var data = _categoryRepository.GetCategoryById(id);
        //    return View(data);
        //}
        //public List<CategoryModel> SearchCategories(string categoryName)
        //{
        //    return _categoryRepository.SearchCategories(categoryName);
        //}
        public ViewResult AddNewCategory(bool isSuccess = false, int categorytId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CategoryID = categorytId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(CategoryModel categoryModel)
        {
            int id = _categoryRepository.AddNewCategory(categoryModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewCategory), new { isSuccess = true, categorytId = id });
            }
            return View();
        }

        public ViewResult EditNewCategory(bool isSuccess = false, int categorytId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CategoryID = categorytId;
            return View();
        }

        [HttpPost]
        public IActionResult EditNewCategory(CategoryModel categoryModel)
        {
            _categoryRepository.EditNewCategory(categoryModel);
            
            return RedirectToAction(nameof(GetAllCategories));
        }

        public async Task<IActionResult> DeleteCategory(int categorytId = 0)
        {
            await _categoryRepository.DeleteCategoryById(categorytId);
            return RedirectToAction(nameof(GetAllCategories));
        }

    }
}
