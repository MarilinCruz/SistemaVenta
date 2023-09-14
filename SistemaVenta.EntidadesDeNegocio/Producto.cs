using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.EntidadesDeNegocio
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "Categoria es Obligatorio")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Codigo es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(150, ErrorMessage = "Maximo 150 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Categoria> Categoria { get; set; }
    }
}
