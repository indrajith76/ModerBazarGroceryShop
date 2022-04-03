using ModerBazarGroceryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModerBazarGroceryShop.Repository
{
    public class UserRepository
    {
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
