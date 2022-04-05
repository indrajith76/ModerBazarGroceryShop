using Microsoft.AspNetCore.Mvc;
using ModerBazarGroceryShop.Models;
using ModerBazarGroceryShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRepository _adminRepository = null;

        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }
        public List<AdminModel> GetAllAdmin()
        {
            return _adminRepository.GetAllAdmin();
        }
        public AdminModel GetAdmin(int id)
        {
            return _adminRepository.GetAdminById(id);
        }
        public List<AdminModel> SearchAdmin(string adminName, string designation)
        {
            return _adminRepository.SearchAdmin(adminName, designation);
        }
    }
}
