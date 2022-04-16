using ModerBazarGroceryShop.Data;
using ModerBazarGroceryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Repository
{
    public class UserRepository
    {
        private readonly ModerBazarContext _context = null;
        public UserRepository(ModerBazarContext context)
        {
            _context = context;
        }

        public int AddNewUser(UserModel model)
        {
            var newUser = new Users()
            {
                UserName = model.UserName,
                Location = model.Location,
                PhoneNo = model.PhoneNo,
                Password = model.Password,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser.UserID;
        }

        public List<UserModel> GetAllUsers()
        {
            return DataSource();
        }
        public UserModel GetUserById(int id)
        {
            return DataSource().Where(x => x.UserID == id).FirstOrDefault();
        }
        public List<UserModel> SearchUser(string location,int phoneNo)
        {
            return DataSource().Where(x => x.Location.Contains(location) || x.PhoneNo == phoneNo).ToList();
        }
        private List<UserModel> DataSource()
        {
            return new List<UserModel>()
            {
                new UserModel(){UserID=1,UserName="indra",Location="ctg",PhoneNo=10101,Password="12dd"},
                new UserModel(){UserID=2,UserName="Rahim",Location="Dhaka",PhoneNo=5947,Password="45re"}
            };
        }
    }
}
