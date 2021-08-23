using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    #region VehiculoData
    public class Vehiculo
    {
        [Key]
        public int id_vehiculo { get; set; }

        [StringLength(30,ErrorMessage ="La placa tiene un maximo de 30 caracteres")]
        [Required(ErrorMessage = "Debe digitar una placa")]
        public string placa { get; set; }

        [Required(ErrorMessage = "Debe digitar un dueño")]
        public string dueño { get; set; }

        [StringLength(50,ErrorMessage = "La marca tiene un maximo de 50 caracteres")]
        [Required(ErrorMessage = "Debe digitar una marca")]
        public string marca { get; set; }

    }
    #endregion
}
