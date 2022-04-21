using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Display(Name ="Category Image")]
        public IFormFile CatImage { get; set; }
        public string CategoryImage { get; set; }
    }
}
