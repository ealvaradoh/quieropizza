using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    public class ClientesController : Controller
    {
        ClientesBL _clientesBL;
        public ClientesController()
        {
            _clientesBL = new ClientesBL();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clientesBL.ObtenerClientes();
            return View(listadeClientes);
        }

        //Crear un cliente
        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();
            return View(nuevoCliente);
        }
        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //EDITAR UN CLIENTE
        public ActionResult Editar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //DETALLE DE CLIENTE
        public ActionResult Detalle(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }

        //ELIMINAR UN CLIENTE
        public ActionResult Eliminar(int id)
        {
            var cliente = _clientesBL.ObtenerCliente(id);
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            _clientesBL.Eliminar(cliente.Id);
            return RedirectToAction("Index");
        }
    }
}