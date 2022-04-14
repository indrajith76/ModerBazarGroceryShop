using ModerBazarGroceryShop.Data;
using ModerBazarGroceryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Repository
{
    public class ProductRepository
    {
        private readonly ModerBazarContext _context = null;
        public ProductRepository(ModerBazarContext context)
        {
            _context = context;
        }

        public int AddNewProduct(ProductModel model)
        {
            var newProduct = new Products()
            {
                ProductName = model.ProductName,
                BrandName = model.BrandName,
                ProductCategories = model.ProductCategories,
                InStock = model.InStock,
                ProductDetails = model.ProductDetails,
                Quantity = model.Quantity,
                Price = model.Price,
                Image = model.Image,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return newProduct.ProductID;
        }

        public List<ProductModel> GetAllProducts()
        {
            return DataSource();
        }
        public ProductModel GetProductById(int id)
        {
            return DataSource().Where(x => x.ProductID == id).FirstOrDefault();
        }
        public List<ProductModel> SearchProduct(string productName,string brandName)
        {
            return DataSource().Where(x => x.ProductName.Contains(productName) || x.BrandName.Contains(brandName)).ToList();
        }
        private List<ProductModel> DataSource()
        {
            return new List<ProductModel>()
            {
                new ProductModel(){ProductID = 1, ProductName ="Rice",BrandName="Indian Katari",ProductCategories="Xyz",InStock="Yes",ProductDetails="slkdfjasldfjsldk",Quantity="1kg",Price=120,Image="/ffff/img.png"},
                new ProductModel(){ProductID = 2, ProductName ="Suger",BrandName="abulKhair",ProductCategories="Zws",InStock="Yes",ProductDetails="slkdfjasldfjsldk",Quantity="1kg",Price=100,Image="/ffff/img.jpg"}
            };
        }
    }
}
