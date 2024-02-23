using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaCursos.Shared
{
    public class Curso
    {
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe tener maximo {1} caracteres")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(2000, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        public string Descripcion { get; set; } = null!;

        [Column(TypeName="decimal(18,2)")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Precio { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Programa del curso")]
        public string Programa { get; set; } = null;

        [Display(Name = "Imagen")]
        public string Imagen { get; set; } = null!;
    }
}
