using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
