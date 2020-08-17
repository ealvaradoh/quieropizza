using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    //[Authorize]
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenBL;
        ProductosBL _productosBL;

        public OrdenDetalleController()
        {
            _ordenBL = new OrdenesBL();
            _productosBL = new ProductosBL();
        }
        // GET: OrdenDetalle
        public ActionResult Index(int id)
        {
            var orden = _ordenBL.ObtenerOrden(id);
            orden.ListaOrdenDetalle = _ordenBL.ObtenerOrdenDetalle(id);
            return View(orden);
        }

        // CREAR UNA ORDEN DETALLE
        public ActionResult Crear(int id)
        {
            var nuevaOrdenDetalle = new OrdenDetalle();
            nuevaOrdenDetalle.OrdenId = id;

            var productos = _productosBL.ObtenerProductos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(nuevaOrdenDetalle);
        }
        [HttpPost]
        public ActionResult Crear(OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                if (ordenDetalle.ProductoId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View (ordenDetalle);
                }
                _ordenBL.GuardarOrdenDetalle(ordenDetalle);
                return RedirectToAction("Index", new { id = ordenDetalle.OrdenId});
            }
            var productos = _productosBL.ObtenerProductos();
            ViewBag.ProductoId = new SelectList("Id", "Descripcion");
            return View(ordenDetalle);
        }

        // Eliminar un detalle de orden
        public ActionResult Eliminar(int id)
        {
            var ordenDetalle = _ordenBL.ObtenerOrdenDetalleID(id);
            return View(ordenDetalle);
        }
        [HttpPost]
        public ActionResult Eliminar(OrdenDetalle ordenDetalle)
        {
            _ordenBL.EliminarOrdenDetalle(ordenDetalle.Id);
            return RedirectToAction("Index", new { id = ordenDetalle.OrdenId});
        }
    }
}