using EstudiodeCasoJosef.Data;
using EstudiodeCasoJosef.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EstudiodeCasoJosef.Controllers
{
    [Route("factura")]
    public class FacturaController : Controller
    {
        private readonly IFacturaService _facturaService;
        private readonly IProductoService _productoService;

        public FacturaController(
            IFacturaService facturaService,
            IProductoService productoService)
        {
            _facturaService = facturaService;
            _productoService = productoService;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            var facturas = _facturaService.ObtenerTodas();
            return View(facturas);
        }

        [HttpGet("agregar")]
        public IActionResult Agregar()
        {
            ViewBag.Productos = _productoService.ObtenerTodos();
            return View(new Factura());
        }

        [HttpPost("agregar")]
        public IActionResult Agregar(Factura factura, int productoId, int cantidad)
        {
            ViewBag.Productos = _productoService.ObtenerTodos();

            if (!ModelState.IsValid)
                return View(factura);

            var producto = _productoService.ObtenerDetalle(productoId);

            if (producto == null || cantidad <= 0)
            {
                ModelState.AddModelError("", "Debe seleccionar un producto válido.");
                return View(factura);
            }

            factura.Detalles = new List<DetalleFactura>
            {
                new DetalleFactura
                {
                    ProductoId = producto.Id,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                }
            };

            _facturaService.CrearFactura(factura);

            return RedirectToAction("Index");
        }

        [HttpGet("descargar/{id:int}")]
        public FileResult Descargar(int id)
        {
            var factura = _facturaService.ObtenerDetalle(id);

            if (factura == null)
            {
                return File(
                    Encoding.UTF8.GetBytes("Factura no encontrada"),"text/plain","Error.txt");
            }

            string texto = "FACTURA\n";
            texto += "Cliente: " + factura.NombreCliente + "\n";
            texto += "Fecha: " + factura.Fecha + "\n\n";
            foreach (var item in factura.Detalles)
            {
                texto += item.NombreProducto +
                " - Cantidad: " + item.Cantidad + " - Precio: " + item.PrecioUnitario + " - Total: " + (item.Cantidad * item.PrecioUnitario) + "\n";
            }

            texto += "\nSubtotal: " + factura.Subtotal;
            texto += "\nImpuesto: " + factura.Impuesto;
            texto += "\nTotal: " + factura.Total;

            return File(Encoding.UTF8.GetBytes(texto),"text/plain","Factura_" + factura.Id + ".txt");
        }
    }
}