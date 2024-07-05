using ValiullinShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace ValiullinShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registration(UserModel userReg, string Password2)
        {
            if (ModelState.IsValid)
            {
                var context = new ValiullinShopDBContext(); 
                var user = context.Users.FirstOrDefault(u => u.Login == userReg.Login);
                if (user != null)
                {
                    userReg.Error = "Такой логин уже используется!";
                    return View("Reg", userReg);
                }

				if (userReg.Password != Password2)
				{
					userReg.Error = "Пароли не совпадают!";
					return View("Reg", userReg);
				}

                User newUser = new User
                {
                    Id = 0,
                    FirstName = userReg.FirstName,
                    LastName = userReg.LastName,
                    MiddleName = userReg.MiddleName,
                    Phone = userReg.Phone,
                    Email = userReg.Email,
                    Address = userReg.Address,
                    Role = 0,
                    Login = userReg.Login,
                    Password = userReg.Password,

                };
                context.Users.Add(newUser); 
                context.SaveChanges();

                UserModel authInfo = new UserModel
                {
                    Login = userReg.Login,
                    Password = userReg.Password
                };

                IActionResult authResult = Index(authInfo) as RedirectToActionResult;

                return authResult;
            }
            return View(userReg);
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserModel userAuth = new UserModel();
            return View(userAuth);
        }

        [HttpPost]
        public IActionResult Index(UserModel userAuth)
        {
			UsersRepository rep = new UsersRepository();
			UserModel user = rep.GetAuthUser(userAuth);
            if (user == null)
            {
                userAuth.Error = userAuth.Error + "Некорректно введен логин или пароль!";
                return View(userAuth);
            }
            HttpContext.Session.Set<UserModel>("User", user);
		    return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
        public IActionResult Reg()
        {
            return View("Reg");
        }

    }
}