using Data;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Diagnostics;
using Utilities;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                Products = _context.Product.Include(x => x.Category).Include(x => x.AppType),
                Categories = _context.Category
            };

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Detail(int id)
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }

            DetailViewModel vm = new DetailViewModel
            {
                Product = _context.Product.Include(x => x.Category).Include(x => x.AppType).Where(p => p.Id == id).FirstOrDefault(),
                isInCart = false
            };

            foreach (var item in shoppingCarts)
            {
                if (item.ProductId == id)
                {
                    vm.isInCart = true;
                }
            }

            return View(vm);
        }

        [HttpPost, ActionName("Detail")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailPost(int id)
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }

            shoppingCarts.Add(new ShoppingCart { ProductId = id });
            HttpContext.Session.Set(Constants.ShoppingCartSession, shoppingCarts);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Constants.ShoppingCartSession).Count() > 0)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(Constants.ShoppingCartSession);
            }

            var productToRemove = shoppingCarts.SingleOrDefault(x => x.ProductId == id);

            if (productToRemove != null)
            {
                shoppingCarts.Remove(productToRemove);
            }

            HttpContext.Session.Set(Constants.ShoppingCartSession, shoppingCarts);

            return RedirectToAction("Index");
        }
    }
}
