using Microsoft.AspNetCore.Mvc;
using ValiullinShop.Models.Repository;
using ValiullinShop.Models;

namespace ValiullinShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart == null)
            {
                return View("CartMessage");
            }
            return View(cart);
        }
        public IActionResult OrderDetails ()
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            
            return View("OrderDetails", cart);
        }
		public IActionResult OrderSubmit(string firstname, string lastname, string middlename, string phone, string email, string address, string paymentMethod)
		{
			var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
			var orderDetails = new OrderModel(firstname, lastname, middlename, phone, email, address, paymentMethod);
			ViewBag.OrderDetails = orderDetails;
			return View("OrderSubmit", cart);
		}
		public IActionResult Add(int id)
        {
            ProductsRepository repository = new ProductsRepository();
            ProductModel product = repository.FindById(id);

            CartItem cartItem = new CartItem(product);
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            //Cart cart = new Cart(cartItem);
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.Add(id);
            HttpContext.Session.Set("Cart", cart);

            return View("Index", cart);
        }
        public IActionResult Remove(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.Remove(id);
            }
            HttpContext.Session.Set("Cart", cart);

            return View("Index", cart);
        }

        public IActionResult Update(int id, int num)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.Update(id, num);
            }
            HttpContext.Session.Set("Cart", cart);

            return View("Index", cart);
        }

        public IActionResult UpdatePlus(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.UpdatePlus(id);
            }
            HttpContext.Session.Set("Cart", cart);

            return View("Index", cart);
        }

        public IActionResult UpdateMinus(int id)
        {
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                cart.UpdateMinus(id);
            }
            HttpContext.Session.Set("Cart", cart);

            return View("Index", cart);
        }

        public int GetAllCartItems()
        {
            int items;
            var cart = (Cart)HttpContext.Session.Get<Cart>("Cart");
            if (cart != null)
            {
                items = cart.GetAllCartItems();
                return items;
            }
            else
            {
                return 0;
            }
        }
        public IActionResult Submit()
        {
			HttpContext.Session.Remove("Cart");
			return RedirectToAction("Index","Home");
        }
    }
}
