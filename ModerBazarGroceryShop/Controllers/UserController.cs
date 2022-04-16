using Microsoft.AspNetCore.Mvc;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository = null;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ViewResult GetAllUsers()
        {
            var data = _userRepository.GetAllUsers();
            return View(data);
        }
        public UserModel GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public List<UserModel> SearchUser(string location, int phoneNo)
        {
            return _userRepository.SearchUser(location, phoneNo);
        }
        public ViewResult AddNewUser(bool isSuccess = false, int userId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.UserId = userId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewUser(UserModel userModel)
        {
            int id = _userRepository.AddNewUser(userModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewUser), new { isSuccess = true, userId = id });
            }
            return View();
        }
    }
}
