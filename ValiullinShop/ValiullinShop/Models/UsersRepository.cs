
using Microsoft.EntityFrameworkCore;
using ValiullinShop.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ValiullinShop.Models
{
    public class UsersRepository
    {
        public List<UserModel> GetAll()
        {
            List<UserModel> users = new List<UserModel>();
            using (ValiullinShopDBContext bd = new ValiullinShopDBContext())
            {
                users = bd.Users.Select(List => new UserModel()
                {
                    Id = List.Id,
                    FirstName = List.FirstName,
                    LastName = List.LastName,
                    MiddleName = List.MiddleName,
                    Phone = List.Phone,
                    Email = List.Email,
                    Address = List.Address,
                    Role = List.Role,
                    Login = List.Login,
                    Password = List.Password,
                }).ToList();
            }
            return users;
        }

		public UserModel GetAuthUser(UserModel model)
		{
			List<UserModel> users = GetAll();
			UserModel user = users.Where(item => item.Login == model.Login && item.Password == model.Password).FirstOrDefault();
			return user;
		}

		public UserModel GetById(int id)
        {
            List<UserModel> users = new List<UserModel>();
            using (ValiullinShopDBContext bd = new ValiullinShopDBContext())
            {
                users = bd.Users.Select(List => new UserModel()
                {
                    Id = List.Id,
                    FirstName = List.FirstName,
                    LastName = List.LastName,
                    MiddleName = List.MiddleName,
                    Phone = List.Phone,
                    Email = List.Email,
                    Address = List.Address,
                    Role = List.Role,
                    Login = List.Login,
                    Password = List.Password,
                }).ToList();
            }

            var user = users.Find(p => p.Id == id);
            return user;
        }
    }
}
