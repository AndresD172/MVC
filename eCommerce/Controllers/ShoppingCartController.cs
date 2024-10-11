using eCommerce.Data;
using eCommerce.Models;
using eCommerce.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using System.Security.Claims;

namespace eCommerce.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }
            

            List<int> items = shoppingCarts.Select(x => x.ProductId).ToList();

            IEnumerable<Product> products = _context.Product.Where(x => items.Contains(x.Id));

            return View(products); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return RedirectToAction("Resume");
        }

        public IActionResult Delete(int id)
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }
            

            shoppingCarts.Remove(shoppingCarts.FirstOrDefault(x => x.ProductId == id));

            HttpContext.Session.Set(Constants.ShoppingCartSession, shoppingCarts);

            return RedirectToAction("Index");
        }

        public IActionResult Resume()
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim? claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }

            List<int> cartElements = shoppingCarts.Select(i => i.ProductId).ToList();


        }
    }
}
