using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ProductRepository _productRepository = null;
        //public HomeController()
        //{
        //    _productRepository = new ProductRepository();
        //}

        public ViewResult Index()
        {
            return View("Index");
        }
        //public ViewResult GetProduct(int id)
        //{
        //    var data = _productRepository.GetProductById(id);
        //    return View(data);
        //}
    }
}
