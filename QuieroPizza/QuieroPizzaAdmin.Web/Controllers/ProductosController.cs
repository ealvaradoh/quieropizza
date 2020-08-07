using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    public class ProductosController : Controller
    {

        ProductosBL _productosBL;
        public ProductosController()
        {
            _productosBL = new ProductosBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProducto = _productosBL.ObtenerProductos();
            return View(listadeProducto);
        }
        
        // CREAR UN PRODUCTO 
        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            return View(nuevoProducto);
        }
        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        // EDITAR UN PRODUCTO
        public ActionResult Editar(int id)
        {
            _productosBL.ObtenerProducto(id);
            return View();
        }
        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        // Detalle
        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        // Eliminar
        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }
        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}