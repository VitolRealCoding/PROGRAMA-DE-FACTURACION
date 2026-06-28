using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.Models;

namespace SistemaFacturacion.Controllers
{
    public class FacturaController : Controller
    {
        private static List<Factura> facturas =
            new List<Factura>();

        // Mostrar facturas
        public IActionResult Index()
        {
            return View(facturas);
        }

        // Formulario para crear
        public IActionResult Crear()
        {
            return View();
        }

        // Guardar factura
        [HttpPost]
        public IActionResult Crear(Factura factura)
        {
            factura.Id = facturas.Count + 1;

            facturas.Add(factura);

            return RedirectToAction("Index");
        }

        // Formulario para editar
        public IActionResult Editar(int id)
        {
            var factura =
                facturas.FirstOrDefault(f => f.Id == id);

            return View(factura);
        }

        // Modificar factura
        [HttpPost]
        public IActionResult Editar(Factura factura)
        {
            var dato =
                facturas.FirstOrDefault(f => f.Id == factura.Id);

            if (dato != null)
            {
                dato.Cliente = factura.Cliente;
                dato.Producto = factura.Producto;
                dato.Cantidad = factura.Cantidad;
                dato.Precio = factura.Precio;
            }

            return RedirectToAction("Index");
        }

        // Eliminar factura
        public IActionResult Eliminar(int id)
        {
            var factura =
                facturas.FirstOrDefault(f => f.Id == id);

            if (factura != null)
            {
                facturas.Remove(factura);
            }

            return RedirectToAction("Index");
        }
    }
}
