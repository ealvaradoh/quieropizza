using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        [MinLength (3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength (20, ErrorMessage = "Ingrese un máximo de 20 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese un precio")]
        [Range(0, 1000, ErrorMessage = "Ingrese un precio entre 0 y 1,000")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingrese una categoría")]
        public int CategoriaId { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public Categoria Categoria { get; set; }
        public Boolean Activo { get; set; }
    }
}
