using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DataAccess.Services;

namespace Business.Logic
{
    #region MethodsLogicVehiculo_Servicio
    public class Vehiculo_ServicioLogic
    {
        private Vehiculo_ServicioService sv = new Vehiculo_ServicioService();

        public bool PlacaExist(string placa)
        {
            return sv.PlacaExist(placa);
        }

        public int GetID(string placa)
        {
            return sv.GetID(placa);
        }

        public Vehiculo_Servicio Get(int id, int? IdServicio)
        {
            return sv.Find(id, IdServicio);
        }

        public void Add(Vehiculo_Servicio Vehiculo_Servicio)
        {
            sv.Add(Vehiculo_Servicio);
        }

        public void Delete(int id, int? IdServicio)
        {
            sv.Delete(Get(id, IdServicio));
        }

        public  void Dispose()
        {
            sv.Dispose();
        }
    }
    #endregion
}

