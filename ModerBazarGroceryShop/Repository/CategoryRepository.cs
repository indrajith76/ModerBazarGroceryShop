using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModerBazarGroceryShop.Data;
using ModerBazarGroceryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Repository
{
    public class CategoryRepository
    {
        private readonly ModerBazarContext _context = null;
        public CategoryRepository(ModerBazarContext context)
        {
            _context = context;
        }
        public int AddNewCategory(CategoryModel model)
        {
            var newCategory = new Categories()
            {
                CategoryName = model.CategoryName,
                CategoryImage = model.CategoryImage
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return newCategory.CategoryID;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            
            var categories = new List<CategoryModel>();
            var allcategories = await _context.Categories.ToListAsync();
            if (allcategories?.Any() == true)
            {
                foreach (var category in allcategories)
                {
                    categories.Add(new CategoryModel()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryImage = category.CategoryImage

                    });
                }
            }
            return categories;
        }
        

        public async Task<CategoryModel> EditCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                var categoryDetails = new CategoryModel()
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    CategoryImage = category.CategoryImage
                };
                return categoryDetails;
            }
            return null;
        }

        
        public async Task<int> SaveEditCategoryAsync(CategoryModel model)
        {
            var newCategory = new Categories()
            {
                CategoryID = model.CategoryID,
                CategoryName = model.CategoryName,
                CategoryImage = model.CategoryImage
            };
            _context.Categories.Update(newCategory);
            await _context.SaveChangesAsync();

            return newCategory.CategoryID;
        }

        
        public async Task<CategoryModel> DeleteCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                var categoryDel = new CategoryModel()
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                };
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return categoryDel;
            }
            return null;
        }

    }
}
