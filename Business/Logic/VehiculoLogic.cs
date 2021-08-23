using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DataAccess.Services;

namespace Business.Logic
{
    #region MethodsLogicVehiculo
    public class VehiculoLogic
    {
        private VehiculoService sv = new VehiculoService();

        public List<Vehiculo> Index(int? id_servicio)
        {
            return sv.List(id_servicio == null ? 0 : (int)id_servicio);
        }

        public bool Exist(int id)
        {
            return sv.Find(id) != null;
        }

        public bool HaveService(int id)
        {
            return sv.HaveService(id);
        }

        public Vehiculo Get(int id)
        {
            return sv.Find(id);
        }

        public void Add(Vehiculo vehiculo)
        {
            sv.Add(vehiculo);
        }

        public void Edit(Vehiculo vehiculo)
        {
            sv.Edit(vehiculo);
        }
        public void Delete(int id)
        {
            sv.Delete(Get(id));
        }
        public  void Dispose()
        {
            sv.Dispose();
        }
    }
    #endregion
}
