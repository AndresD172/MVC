using eCommerce.Data;
using eCommerce.Models;
using eCommerce.Utils;
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
            IEnumerable<Product> products = _context.Product.Include(x => x.Category).Include(x => x.AppType);

            return View(products);
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

                AppTypes = _context.AppType.Select(c => new SelectListItem
                {
                    Text = c.Name,
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

            IFormFileCollection files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string uploadPath = webRootPath + Constants.ImageUrl;
            string filePath = String.Empty;

            if (productViewModel.Product.Id != 0)
            {
                Product? product = _context.Product.AsNoTracking().FirstOrDefault(x => x.Id == productViewModel.Product.Id);

                filePath = product.ImageUrl;

                if (files.Count() > 0)
                {
                    string file = Path.Combine(uploadPath, filePath);

                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }

                    filePath = FileUtils.WriteImage(uploadPath, files);
                }
                
                productViewModel.Product.ImageUrl = filePath;

                _context.Product.Update(productViewModel.Product);
            }
            else
            {
                filePath = FileUtils.WriteImage(uploadPath, files);

                productViewModel.Product.ImageUrl = filePath;

                _context.Product.Add(productViewModel.Product);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? product = _context.Product.Include(x => x.Category).Include(x => x.AppType).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }

            string webRootPath = _webHostEnvironment.WebRootPath;
            string uploadPath = webRootPath + Constants.ImageUrl;
            string file = Path.Combine(uploadPath, product.ImageUrl);

            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
