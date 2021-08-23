using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    #region ServiciosData
    public class Servicios
    {
        [Key]
        public int id_servicio { get; set; }

        [Required(ErrorMessage = "Debe digitar una descripcion")]
        public string descripción { get; set; }

        [Required(ErrorMessage = "Debe digitar un monto")]
        public int monto { get; set; }
        
    }
    #endregion
}
