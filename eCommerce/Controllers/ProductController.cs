using eCommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Product.Include(x => x.Category).Include(x => x.TipoAplicacion);

            return View();
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categories = _context.Category.Select(x => new SelectListItem {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.categoriesDropDownContent = categories;

            IEnumerable<SelectListItem> tiposAplicacion = _context.TipoAplicacion.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });

            ViewBag.TiposAplicacionDropDownContent = tiposAplicacion;

            Product? product = new Product();
            
            if (id == null)
            {
                product = new Product();

                return View(product);
            }

            product = _context.Product.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
