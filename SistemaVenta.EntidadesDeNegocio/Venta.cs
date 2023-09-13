using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.EntidadesDeNegocio
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Usuario es Obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Producto es Obligatorio")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Nombre Cliente es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string NombreCliente { get; set; }


        [Required(ErrorMessage = "Apellido Cliente es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 30 caracteres")]
        public string ApellidoCliente { get; set; }

        [Required(ErrorMessage = "El Monto de pago es requerido")]
        public decimal MontoPago { get; set; }

        [Required(ErrorMessage = "El monto de cambio es requerido")]
        public decimal MontoCambio { get; set; }

        [Required(ErrorMessage = "El Monto Total es requerido")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
