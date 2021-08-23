using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    #region MethodsVehiculo
    public class VehiculoService
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Vehiculo> List(int id_servicio)
        {
            if (id_servicio == 0)
            {
                return db.Vehiculo.ToList();
            }
            else
            {
                return db.Vehiculo.Where(x => 
                                    db.Vehiculo_Servicio.Any(y=>
                                                y.id_vehiculo ==x.id_vehiculo && 
                                                y.id_servicio == id_servicio)
                                    ).ToList();
            }
        }

        public Vehiculo Find(int id)
        {
            return db.Vehiculo.Find(id);
        }

        public bool HaveService(int id_vehiculo)
        {
            return db.Vehiculo_Servicio.Any(x => x.id_vehiculo == id_vehiculo);
        }

        public void Add(Vehiculo vehiculo)
        {
            db.Vehiculo.Add(vehiculo);
            db.SaveChanges();
        }

        public void Edit(Vehiculo vehiculo)
        {
            db.Entry(vehiculo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Vehiculo vehiculo)
        {
            db.Vehiculo.Remove(vehiculo);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
    #endregion
}
