using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Cliente
    {
        public Cliente()
        {
            Activo = false;
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese un nombre de usuario")]
        [MinLength(3, ErrorMessage = "Su nombre debe ser mínimo de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Nombre no puede exceder de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese un número de teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Tiene que ingresar una dirección")]
        public string Direccion { get; set; }

        public bool Activo { get; set; }
    }
}
