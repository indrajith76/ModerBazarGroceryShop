using ModerBazarGroceryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Repository
{
    public class AdminRepository
    {
        public List<AdminModel> GetAllAdmin()
        {
            return DataSource();
        }
        public AdminModel GetAdminById(int id)
        {
            return DataSource().Where(x => x.AdminId == id).FirstOrDefault();
        }
        public List<AdminModel> SearchAdmin(string adminName, string designation)
        {
            return DataSource().Where(x => x.AdminName.Contains(adminName) || x.Designation.Contains(designation)).ToList();
        }

        private List<AdminModel> DataSource()
        {
            return new List<AdminModel>()
            {
                new AdminModel(){AdminId = 1, AdminName ="Robi", Email="ikkj@gmail.com", Gender="Male", DateOfBirth = "1/3/2002", Designation="manager", Phone=01245, Password="lkkj"},
                new AdminModel(){AdminId = 2, AdminName ="kobi", Email="ikkj@yehoo.com", Gender="Female", DateOfBirth = "1/3/2002", Designation="manager", Phone=01245, Password="leej"}
            };
        }
    }
}
