using eCommerce.Data;
using eCommerce.Models;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                Products = _context.Product.Include(x => x.Category).Include(x => x.TipoAplicacion),
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
            DetailViewModel vm = new DetailViewModel
            {
                Product = _context.Product.Include(x => x.Category).Include(x => x.TipoAplicacion).Where(p => p.Id == id).FirstOrDefault(),
                isInCart = false
            };

            return View(vm);
        }
    }
}
