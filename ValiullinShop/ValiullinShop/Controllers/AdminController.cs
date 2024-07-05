using Microsoft.AspNetCore.Mvc;
using ValiullinShop.Models;
using ValiullinShop.Models.Admin;
using ValiullinShop.Models.Repository;

namespace ValiullinShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ValiullinShopDBContext productDbcontext;
        private readonly AdminRepository _adminRepository;
        public AdminController(ValiullinShopDBContext productDbcontext, AdminRepository adminRepository)
        {
            this.productDbcontext = productDbcontext;
            _adminRepository = adminRepository;
        }
        public IActionResult Index(int? minRan, int? maxRan, double? minLen, double? maxLen, int? power3, int? power7, int? minPrice, int? maxPrice, double? caliber545, double? caliber12, double? caliber308, double? caliber762, int? clip, string sort = null, string search = null,
            string categoryFire = null, string categoryCold = null, string categoryPnevma = null,
             string weaponHide = null, string weaponOpen = null, string cartridgeVint = null, string cartridgeVintPul = null, string cartridgeRuj = null, string cartridgePro = null,
             string bladeD2 = null, string bladeXM = null, string bladeAus = null, string blade14 = null, string handleStk = null, string handleRez = null, string handleDer = null, string handlePro = null,
             string pnevmaGaz = null, string pnevmaPruj = null, string pnevmaNak = null, string bulletMet = null, string bulletMP = null, string bulletRez = null)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            var itemCart = new List<CartItem>();
            ProductsRepository _products = new ProductsRepository();
            List<ProductModel> products = _products.GetAll(minRan, maxRan, minLen, maxLen, power3, power7, minPrice, maxPrice, caliber545, caliber12, caliber308, caliber762, clip, sort, search, categoryFire, categoryCold, categoryPnevma, weaponHide, weaponOpen
                , cartridgeVint, cartridgeVintPul, cartridgeRuj, cartridgePro, bladeD2, bladeXM, bladeAus, blade14, handleStk, handleRez, handleDer, handlePro, pnevmaGaz, pnevmaPruj, pnevmaNak,
                bulletMet, bulletMP, bulletRez);
            if (cart != null)
            {
                foreach (var item in cart.Items)
                {
                    foreach (var product in products)
                    {
                        if (product.Id == item.product.Id)
                        {
                            itemCart.Add(item);
                        }
                    }
                }
                ViewBag.Cart = itemCart;
            }
            int? maxValuePr = products.Max(p => p.Price);
            int? minValuePr = products.Min(p => p.Price);
            int? maxValueLe = (int?)products.Max(p => p.Lenght);
            int? minValueLe = (int?)products.Min(p => p.Lenght);
            int? maxValueRa = products.Max(p => p.Range);
            int? minValueRa = products.Min(p => p.Range);

            #region
            ViewBag.Search = search;
            ViewBag.Sort = sort;
            ViewBag.CategoryFire = categoryFire;
            ViewBag.CategoryCold = categoryCold;
            ViewBag.CategoryPnevma = categoryPnevma;
            ViewBag.WeaponHide = weaponHide;
            ViewBag.WeaponOpen = weaponOpen;
            ViewBag.Caliber545 = caliber545;
            ViewBag.Caliber12 = caliber12;
            ViewBag.Caliber308 = caliber308;
            ViewBag.Caliber762 = caliber762;
            ViewBag.CartridgeVint = cartridgeVint;
            ViewBag.CartridgeVintPul = cartridgeVintPul;
            ViewBag.CartridgeRuj = cartridgeRuj;
            ViewBag.CartridgePro = cartridgePro;
            ViewBag.BladeD2 = bladeD2;
            ViewBag.Blade14 = blade14;
            ViewBag.BladeAus = bladeAus;

            ViewBag.BladeXM = bladeXM;
            ViewBag.HandleStk = handleStk;
            ViewBag.HandleRez = handleRez;
            ViewBag.HandleDer = handleDer;
            ViewBag.HandlePro = handlePro;
            ViewBag.PnevmaGaz = pnevmaGaz;
            ViewBag.PnevmaPruj = pnevmaPruj;
            ViewBag.PnevmaNak = pnevmaNak;
            ViewBag.BulletMet = bulletMet;
            ViewBag.BulletMP = bulletMP;
            ViewBag.BulletRez = bulletRez;
            ViewBag.Clip = clip;
            ViewBag.MaxValue = maxValuePr;
            ViewBag.MinValue = minValuePr;
            ViewBag.Power7 = power7;
            ViewBag.Power3 = power3;
            ViewBag.MaxLen = maxValueLe;
            ViewBag.MinLen = minValueLe;
            ViewBag.MaxRan = maxValueRa;
            ViewBag.MinRan = minValueRa;
            #endregion
            return View(products);
        }
        public IActionResult Details(int id)
        {
            ProductsRepository _products = new ProductsRepository();
            ProductModel products = _products.FindById(id);
            return View("Details", products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(AddProductViewModel addEmployeeRequest)
        {
            _adminRepository.AddProduct(addEmployeeRequest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = productDbcontext.ValiullinShopDBs.FirstOrDefault(x => x.Id == id);
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
                return View(updateModel);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Update(UpdateProductViewModel product)
        {

            _adminRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _adminRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateUser(AddUserViewModel addEmployeeRequest)
        {
            _adminRepository.AddUser(addEmployeeRequest);
            return RedirectToAction("ListOfUsers");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = productDbcontext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                var updateModel = new UpdateUserViewModel()
                {
                    Id = user.Id,
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
                return View(updateModel);
            }
            return RedirectToAction("ListOfUsers");

        }
        [HttpPost]
        public IActionResult UpdateUser(UpdateUserViewModel user)
        {

            _adminRepository.UpdateUser(user);
            return RedirectToAction("ListOfUsers");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            _adminRepository.DeleteUser(id);
            return RedirectToAction("ListOfUsers");
        }
        public IActionResult ListOfUsers()
        {
            List<User> users = productDbcontext.Users.ToList();
            return View(users);
        }
    }
}
