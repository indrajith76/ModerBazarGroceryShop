using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Data
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ProductCategories { get; set; }
        public string InStock { get; set; }
        public string ProductDetails { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
