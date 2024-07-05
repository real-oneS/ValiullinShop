using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Diagnostics;
using ValiullinShop.Models;
using ValiullinShop.Models.Repository;

namespace ValiullinShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger, ProductsRepository product)
        {
            _logger = logger;
        }
      
        public IActionResult Index(int? minRan,int? maxRan,double? minLen,double? maxLen,int? power3, int? power7, int? minPrice,int? maxPrice,double? caliber545, double? caliber12, double? caliber308, double? caliber762, int? clip, string sort=null,string search=null, 
            string categoryFire = null, string categoryCold = null, string categoryPnevma = null,
             string weaponHide = null, string weaponOpen = null, string cartridgeVint = null, string cartridgeVintPul = null, string cartridgeRuj = null, string cartridgePro = null,
             string bladeD2=null, string bladeXM=null, string bladeAus=null,string blade14=null, string handleStk = null, string handleRez = null, string handleDer = null, string handlePro = null,
             string pnevmaGaz=null,string pnevmaPruj = null, string pnevmaNak = null, string bulletMet=null,string bulletMP=null,string bulletRez=null)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            var itemCart = new List<CartItem>();
            ProductsRepository _products = new ProductsRepository();
            List<ProductModel> products =  _products.GetAll(minRan,maxRan,minLen,maxLen,power3,power7,minPrice,maxPrice,caliber545,caliber12,caliber308,caliber762,clip, sort, search, categoryFire,categoryCold,categoryPnevma, weaponHide, weaponOpen
                ,cartridgeVint,cartridgeVintPul,cartridgeRuj,cartridgePro,bladeD2,bladeXM,bladeAus,blade14,handleStk,handleRez,handleDer,handlePro, pnevmaGaz, pnevmaPruj,pnevmaNak,
                bulletMet,bulletMP,bulletRez);
            if (cart != null)
            {
                foreach(var item in cart.Items)
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
            ViewBag.CategoryCold=categoryCold;
            ViewBag.CategoryPnevma = categoryPnevma;
            ViewBag.WeaponHide = weaponHide;
            ViewBag.WeaponOpen = weaponOpen;
            ViewBag.Caliber545=caliber545;
            ViewBag.Caliber12=caliber12;
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
            ViewBag.HandlePro= handlePro;
            ViewBag.PnevmaGaz = pnevmaGaz;
            ViewBag.PnevmaPruj = pnevmaPruj;
            ViewBag.PnevmaNak= pnevmaNak;
            ViewBag.BulletMet= bulletMet;
            ViewBag.BulletMP= bulletMP; 
            ViewBag.BulletRez= bulletRez;
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ContentResult GetString(string id)
        {
            string a = "<h1>Valiullin</h1>";
            return Content(a,"text/html");
        }
        public IActionResult Diman()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            ProductsRepository _products = new ProductsRepository();
            ProductModel products = _products.FindById(id);
            HttpContext.Session.Set("Name", products);
			return View("Details",products);
        }

        

    }
}