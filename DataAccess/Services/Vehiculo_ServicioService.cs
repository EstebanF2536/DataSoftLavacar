using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    #region MethodsVehiculo_Servicio
    public class Vehiculo_ServicioService
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public bool PlacaExist(string placa)
        {
            return db.Vehiculo.Any(x => x.placa == placa);
        }
        public int GetID(string placa)
        {
            return db.Vehiculo.Where(x => x.placa == placa).ToList()[0].id_vehiculo;
        }

        public void Add(Vehiculo_Servicio Vehiculo_Servicio)
        {
            db.Vehiculo_Servicio.Add(Vehiculo_Servicio);
            db.SaveChanges();
        }

        public Vehiculo_Servicio Find(int id, int? idServicio)
        {
            var obj = (from v in db.Vehiculo_Servicio
                       where v.id_servicio == idServicio && v.id_vehiculo == id
                       select v).FirstOrDefault();

            return obj;
        }

        public void Delete(Vehiculo_Servicio Vehiculo_Servicio)
        {
            db.Vehiculo_Servicio.Remove(Vehiculo_Servicio);

            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
    #endregion
}
