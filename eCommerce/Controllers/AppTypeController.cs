using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace eCommerce.Controllers
{
    public class AppTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<AppType> appTypes = _context.AppType;

            return View(appTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppType appType)
        {
            if (!ModelState.IsValid)
            {
                return View("AppType");
            }

            _context.Add(appType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tipoAplicacion = _context.AppType.Find(id);

            if (tipoAplicacion == null)
            {
                return NotFound();
            }

            return View(tipoAplicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AppType appType)
        {
            if (!ModelState.IsValid)
            {
                return View("AppType");
            }

            _context.Update(appType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tipoAplicacion = _context.AppType.Find(id);

            if (tipoAplicacion == null)
            {
                return NotFound();
            }

            return View(tipoAplicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(AppType AppType)
        {
            if (AppType == null)
            {
                return NotFound();
            }

            _context.Remove(AppType);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
