using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAplicacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> tiposAplicaciones = _context.TipoAplicacion;

            return View(tiposAplicaciones);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {
            if (!ModelState.IsValid)
            {
                return View("TipoAplicacion");
            }

            _context.Add(tipoAplicacion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tipoAplicacion = _context.TipoAplicacion.Find(id);

            if (tipoAplicacion == null)
            {
                return NotFound();
            }

            return View(tipoAplicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TipoAplicacion tipoAplicacion)
        {
            if (!ModelState.IsValid)
            {
                return View("TipoAplicacion");
            }

            _context.Update(tipoAplicacion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tipoAplicacion = _context.TipoAplicacion.Find(id);

            if (tipoAplicacion == null)
            {
                return NotFound();
            }

            return View(tipoAplicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(TipoAplicacion tipoAplicacion)
        {
            if (tipoAplicacion == null)
            {
                return NotFound();
            }

            _context.Remove(tipoAplicacion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
