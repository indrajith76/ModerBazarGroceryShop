using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
        [Display(Name ="Product Category")]
        public int ProductCategoriesId { get; set; }
        public string ProductCategories { get; set; }
        public string InStock { get; set; }
        [Display(Name ="Product Details")]
        public string ProductDetails { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
        public IFormFile ProductImage { get; set; }
        public string Image { get; set; }
    }
}
