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
        public UserController()
        {
            _userRepository = new UserRepository();
        }
        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public UserModel GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public List<UserModel> SearchUser(string location, int phoneNo)
        {
            return _userRepository.SearchUser(location, phoneNo);
        }
    }
}
