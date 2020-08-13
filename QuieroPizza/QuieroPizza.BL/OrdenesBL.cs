using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }
        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();
        }

        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .OrderBy(r => r.Cliente.Nombre)
                .ThenBy(r => r.ClienteId)
                .ToList();
            return ListadeOrdenes;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Ordenes
                 .Include("Cliente").FirstOrDefault(p => p.Id == id);
            return orden;
        }

        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listaOrdenesDetalle = _contexto.OrdenDetalles
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId).ToList();

            return listaOrdenesDetalle;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenexistente = _contexto.Ordenes.Find(orden.Id);
                ordenexistente.ClienteId = orden.ClienteId;
                ordenexistente.Activo = orden.Activo;
            }
            _contexto.SaveChanges();
        }

        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            ordenDetalle.Precio = ordenDetalle.Producto.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _contexto.OrdenDetalles.Add(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
