﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SistemaVenta.EntidadesDeNegocio
{
    public class Proveedor
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Correo es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Telefono es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Telefono { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }

       // public List<Producto> Productos { get; set; }
    }
}
