using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddNewProduct(ProductModel model)
        {
            var newProduct = new Products()
            {
                ProductName = model.ProductName,
                BrandName = model.BrandName,
                CategoryID = model.ProductCategoriesId,
                InStock = model.InStock,
                ProductDetails = model.ProductDetails,
                Quantity = model.Quantity,
                Price = model.Price,
                Image = model.Image,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

             return newProduct.ProductID;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var products = new List<ProductModel>();
            var allproducts = await _context.Products.Include(a => a.Categories).ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
                {
                    products.Add(new ProductModel()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        BrandName = product.BrandName,
                        ProductCategoriesId = product.CategoryID,
                        ProductCategories = product.Categories.CategoryName,
                        InStock = product.InStock,
                        ProductDetails = product.ProductDetails,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        Image = product.Image

                    });
                }
            }
            return products;
        }
        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.ProductID == id).Select(product => new ProductModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                BrandName = product.BrandName,
                ProductCategoriesId = product.CategoryID,
                ProductCategories = product.Categories.CategoryName,
                InStock = product.InStock,
                ProductDetails = product.ProductDetails,
                Quantity = product.Quantity,
                Price = product.Price,
                Image = product.Image
            }).FirstOrDefaultAsync();
        }
        public async Task<List<ProductModel>> GetProductByCatId(int id)
        {
            return await _context.Products.Where(x => x.CategoryID == id).Select(product => new ProductModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                BrandName = product.BrandName,
                ProductCategoriesId = product.CategoryID,
                ProductCategories = product.Categories.CategoryName,
                InStock = product.InStock,
                ProductDetails = product.ProductDetails,
                Quantity = product.Quantity,
                Price = product.Price,
                Image = product.Image
            }).ToListAsync();
        }


        public async Task<List<ProductModel>> SearchProduct(string searchText)
        {
            return await _context.Products.Where(x => x.ProductName.Contains(searchText) || x.BrandName.Contains(searchText)).Distinct().Select(product => new ProductModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                BrandName = product.BrandName,
                ProductCategoriesId = product.CategoryID,
                ProductCategories = product.Categories.CategoryName,
                InStock = product.InStock,
                ProductDetails = product.ProductDetails,
                Quantity = product.Quantity,
                Price = product.Price,
                Image = product.Image
            }).ToListAsync();
        }

        public async Task<ProductModel> EditProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                var productDetails = new ProductModel()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    BrandName = product.BrandName,
                    ProductCategoriesId = product.CategoryID,
                    //ProductCategories = product.Categories.CategoryName,
                    InStock = product.InStock,
                    ProductDetails = product.ProductDetails,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Image = product.Image
                };
                return productDetails;
            }
            return null;
        }

        public async Task<int> EditProductsAsync(ProductModel model)
        {
            var newProduct = new Products()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                BrandName = model.BrandName,
                CategoryID = model.ProductCategoriesId,
                InStock = model.InStock,
                ProductDetails = model.ProductDetails,
                Quantity = model.Quantity,
                Price = model.Price,
                Image = model.Image
            };
            _context.Products.Update(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.ProductID;
        }

        public async Task<ProductModel> DeleteProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                var productDel = new ProductModel()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    BrandName = product.BrandName,
                    ProductCategoriesId = product.CategoryID,
                    //ProductCategories = product.Categories.CategoryName,
                    InStock = product.InStock,
                    ProductDetails = product.ProductDetails,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Image = product.Image
                };
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return productDel;
            }
            return null;
        }
    }
}
