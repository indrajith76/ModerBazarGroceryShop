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
        public ViewResult GetAllCategories()
        {
            var data = _categoryRepository.GetAllCategories();
            return View(data);
        }

        public ViewResult GetCategoryById(int id)
        {
            var data = _categoryRepository.GetCategoryById(id);
            return View(data);
        }
        public List<CategoryModel> SearchCategories(string categoryName)
        {
            return _categoryRepository.SearchCategories(categoryName);
        }
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
    }
}
