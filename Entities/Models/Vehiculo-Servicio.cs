using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    #region Vehiculo-ServicioData
    public class Vehiculo_Servicio
    {
        [Key]
        public int id_vehiculo_servicio { get; set; }
        [Required]
        public int id_servicio { get; set; }
        [Required]
        public int id_vehiculo { get; set; }
    }
    #endregion
}
