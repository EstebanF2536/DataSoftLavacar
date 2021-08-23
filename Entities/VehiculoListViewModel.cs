using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.VehiculoListViewModel
{
    public class VehiculoListViewModel
    {
        public List<Vehiculo> VehiculosList { get; set; }

        public int? IdServicio { get; set; }
    }
}