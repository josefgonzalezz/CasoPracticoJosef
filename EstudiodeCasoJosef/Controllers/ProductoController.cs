using EstudiodeCasoJosef.Data;
using EstudiodeCasoJosef.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstudiodeCasoJosef.Controllers
{
    [Route("producto")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_productoService.ObtenerTodos());
        }

        [HttpGet("agregar")]
        public IActionResult Agregar()
        {
            return View(new Producto());
        }

        [HttpPost("agregar")]
        public IActionResult Agregar(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            _productoService.Agregar(producto);

            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            _productoService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}