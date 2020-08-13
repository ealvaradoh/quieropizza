using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenesBL;
        ProductosBL _productosBL;
        public OrdenDetalleController()
        {
            _ordenesBL = new OrdenesBL();
            _productosBL = new ProductosBL();
        }
        // GET: OrdenDetalle
        public ActionResult Index(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            orden.ListadeOrdenDetalle = _ordenesBL.ObtenerOrdenDetalle(id);
            return View(orden);
        }

        public ActionResult Agregar(int id)
        {
            var nuevaOrdenDetalle = new OrdenDetalle();
            nuevaOrdenDetalle.OrdenId = id;

            var productos = _productosBL.ObtenerProductos();
            ViewBag.ProductoId =
                new SelectList(productos, "Id", "Nombre");

            return View(nuevaOrdenDetalle);
        }
        [HttpPost]
        public ActionResult Agregar(OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                if (ordenDetalle.ProductoId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(ordenDetalle);
                }
                _ordenesBL.GuardarOrdenDetalle(ordenDetalle);
                return RedirectToAction("Index", new { id = ordenDetalle.OrdenId});
            }
            var productos = _productosBL.ObtenerProductos();
            ViewBag.ProductoId =
                new SelectList(productos, "Id", "Nombre");

            return View(ordenDetalle);
        }
    }
}