using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListadeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Cliente>();
        }

        // Lógica en el sistema
        public List<Cliente> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes.ToList();
            return ListadeClientes;
        } 

        public Cliente ObtenerCliente(int id)
        {
            var cliente = _contexto.Clientes.Find(id);
            return cliente;
        }

        public void GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteexistente = _contexto.Clientes.Find(cliente.Id);
                clienteexistente.Id = cliente.Id;
                clienteexistente.Nombre = cliente.Nombre;
                clienteexistente.Telefono = cliente.Telefono;
                clienteexistente.Direccion = cliente.Direccion;
                clienteexistente.Activo = cliente.Activo;
            }
            _contexto.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var cliente = _contexto.Clientes.Find(id);
            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }
    }
}
