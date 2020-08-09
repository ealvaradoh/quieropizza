using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;
        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listaCategorias = _categoriasBL.ObtenerCategorias();
            return View(listaCategorias);
        }


        // CREAR UNA CATEGORIA 
        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();
            return View(nuevaCategoria);
        }
        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            _categoriasBL.GuardarCategoria(categoria);
            return RedirectToAction("Index");
        }

        // EDITAR UNA CATEGORIA
        public ActionResult Editar(int id)
        {
            _categoriasBL.ObtenerCategoria(id);
            return View();
        }
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            _categoriasBL.GuardarCategoria(categoria);
            return RedirectToAction("Index");
        }

        // Detalle
        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        // Eliminar UNA CATEGORIA
        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }
        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}