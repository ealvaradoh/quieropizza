﻿using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizzaAdmin.Web.Admin.Controllers
{
    public class ProductosController : Controller
    {

        ProductosBL _productosBL;
        CategoriasBL _categoriasBL;
        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();
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
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");
            
            return View(nuevoProducto);
        }
        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Ingrese una categoría");

                    var categoriasingrese = _categoriasBL.ObtenerCategorias();
                    ViewBag.CategoriaId =
                        new SelectList(categoriasingrese, "Id", "Descripcion");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }
                _productosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");
            return View(producto);
        }

        // EDITAR UN PRODUCTO
        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                 new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }
        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {

                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        // Detalle
        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categoria = _categoriasBL.ObtenerCategorias();
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

        //Guardar una imagen
        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}