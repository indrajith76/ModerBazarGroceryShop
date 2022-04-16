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
                CategoryName = model.CategoryName
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return newCategory.CategoryID;
        }

        public List<CategoryModel> GetAllCategories()
        {
            return DataSource();
        }
        public CategoryModel GetCategoryById(int id)
        {
            return DataSource().Where(x => x.CategoryID == id).FirstOrDefault();
        }
        public List<CategoryModel> SearchCategories(string categoryName)
        {
            return DataSource().Where(x => x.CategoryName.Contains(categoryName)).ToList();
        }
        private List<CategoryModel> DataSource()
        {
            return new List<CategoryModel>()
            {
                new CategoryModel(){CategoryID = 1, CategoryName ="Rice"},
                new CategoryModel(){CategoryID = 2, CategoryName ="Suger"}
            };
        }
    }
}
