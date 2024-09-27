using eCommerce.Data;
using eCommerce.Models;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Product.Include(x => x.Category).Include(x => x.TipoAplicacion);

            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = new Product(),

                Categories = _context.Category.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),

                TipoAplicacion = _context.TipoAplicacion.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }),
            };

            if (id == null)
            {
                return View(productViewModel);
            }

            productViewModel.Product = _context.Product.Find(id);

            if (productViewModel.Product == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            if (productViewModel.Product.Id == 0)
            {
                // Lógica de actualización
                
            }

            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            string uploadPath = webRootPath + Constrains.ImageUrl;
            string filename = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(uploadPath, filename + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            };

            productViewModel.Product.ImageUrl = filename + extension;

            _context.Product.Add(productViewModel.Product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
