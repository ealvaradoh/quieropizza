﻿using QuieroPizza.BL;
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
    }
}