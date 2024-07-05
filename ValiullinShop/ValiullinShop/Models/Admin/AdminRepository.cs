using ValiullinShop.Models;
namespace ValiullinShop.Models.Admin
{
    public class AdminRepository
    {
        private readonly ValiullinShopDBContext _context;
        public AdminRepository(ValiullinShopDBContext context)
        {
            _context = context;
        }

        public void UpdateProduct(int id)
        {
            var product = _context.ValiullinShopDBs.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                var updateModel = new UpdateProductViewModel()
                {
                    Id = product.Id,
                    Category = product.Category,
                    Brand = product.Brand,
                    Model = product.Model,
                    Price = product.Price,
                    Description = product.Description,
                    Image = product.Image,
                    Caliber = product.Caliber,
                    Cartridge = product.Cartridge,
                    Clip = product.Clip,
                    Power = product.Power,
                    Pneumatics = product.Pneumatics,
                    Bullet = product.Bullet,
                    Blade = product.Blade,
                    Handle = product.Handle,
                    Lenght = product.Lenght,
                    Range = product.Range,
                    Weapon = product.Weapon
                };
            }
        }
        public void UpdateProduct(UpdateProductViewModel product)
        {
            var productToUpdate = _context.ValiullinShopDBs.Find(product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Category = product.Category;
                productToUpdate.Brand = product.Brand;
                productToUpdate.Model = product.Model;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.Image = product.Image;
                productToUpdate.Caliber = product.Caliber;
                productToUpdate.Cartridge = product.Cartridge;
                productToUpdate.Clip = product.Clip;
                productToUpdate.Power = product.Power;
                productToUpdate.Pneumatics = product.Pneumatics;
                productToUpdate.Bullet = product.Bullet;
                productToUpdate.Blade = product.Blade;
                productToUpdate.Handle = product.Handle;
                productToUpdate.Lenght = product.Lenght;
                productToUpdate.Range = product.Range;
                productToUpdate.Weapon = product.Weapon;
                _context.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            var productToDelete = _context.ValiullinShopDBs.FirstOrDefault(productToDelete => productToDelete.Id == id);
            if (productToDelete != null)
            {
                _context.ValiullinShopDBs.Remove(productToDelete);
                _context.SaveChanges();
            }
        }

        public void AddProduct(AddProductViewModel product)
        {
            var productToAdd = new ValiullinShopDB
            {
                Category = product.Category,
                Brand = product.Brand,
                Model = product.Model,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                Caliber = product.Caliber,
                Cartridge = product.Cartridge,
                Clip = product.Clip,
                Power = product.Power,
                Pneumatics = product.Pneumatics,
                Bullet = product.Bullet,
                Blade = product.Blade,
                Handle = product.Handle,
                Lenght = product.Lenght,
                Range = product.Range,
                Weapon = product.Weapon
            };
            _context.ValiullinShopDBs.Add(productToAdd);
            _context.SaveChanges();
        }
        public void UpdateUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                var updateModel = new UpdateUserViewModel()
                {
                    Id = user.Id,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    MiddleName=user.MiddleName,
                    Phone=user.Phone,
                    Email=user.Email,
                    Address=user.Address,
                    Role=user.Role,
                    Login=user.Login,
                    Password=user.Password

                };
            }
        }
        public void UpdateUser(UpdateUserViewModel user)
        {
            var userToUpdate = _context.Users.Find(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName=user.FirstName;
                userToUpdate.LastName=user.LastName;
                userToUpdate.MiddleName=user.MiddleName;
                userToUpdate.Phone=user.Phone;
                userToUpdate.Email=user.Email;
                userToUpdate.Address=user.Address;
                userToUpdate.Role=user.Role;
                userToUpdate.Login=user.Login;
                userToUpdate.Password=user.Password;
                _context.SaveChanges();
            }
        }
        public void DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(userToDelete => userToDelete.Id == id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }

        public void AddUser(AddUserViewModel user)
        {
            var userToAdd = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Email = user.Email,
                Address = user.Address,
                Role = user.Role,
                Login = user.Login,
                Password = user.Password
            };
            _context.Users.Add(userToAdd);
            _context.SaveChanges();
        }
    }
}
