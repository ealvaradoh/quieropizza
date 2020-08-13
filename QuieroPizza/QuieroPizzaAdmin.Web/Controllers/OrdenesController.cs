using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesBL _ordenesBL;
        ClientesBL _clientesBL;
        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            _clientesBL = new ClientesBL();
        }
        // GET: Ordenes
        public ActionResult Index()
        {
            var listadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(listadeOrdenes);
        }

        // CREAR UNA ORDEN
        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId =
                new SelectList(clientes, "Id", "Nombre");

            return View(nuevaOrden);
        }
        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }
                _ordenesBL.GuardarOrden(orden);
                return RedirectToAction("Index");
            }
            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId =
                new SelectList(clientes, "Id", "Nombre");

            return View(orden);         
        }

        // EDITAR UNA ORDEN
        public ActionResult Editar(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId =
                new SelectList(clientes, "Id", "Nombre", orden.Id);

            return View(orden);
        }
        [HttpPost]
        public ActionResult Editar(Orden orden)
        {
            if (ModelState.IsValid)
            {
                _ordenesBL.GuardarOrden(orden);
                return RedirectToAction("Index");
            }

            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId =
                new SelectList(clientes, "Id", "Nombre", orden.Id);

            return View(orden);
        }

        // DETALLES DE UNA ORDEN
        public ActionResult Detalle(int id)
        {
            var orden = _ordenesBL.ObtenerOrden(id);
            return View(orden);
        }
    }
}