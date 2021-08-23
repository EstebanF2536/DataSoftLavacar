using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    #region MethodsServicios
    public class ServiciosService
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Servicios> List()
        {
            return db.Servicios.ToList();
        }

        public Servicios Find(int id)
        {
            return db.Servicios.Find(id);
        }

        public bool HaveCarro(int id_Servicios)
        {
            return db.Vehiculo_Servicio.Any(x => x.id_servicio == id_Servicios);
        }

        public void Add(Servicios Servicios)
        {
            db.Servicios.Add(Servicios);
            db.SaveChanges();
        }

        public void Edit(Servicios Servicios)
        {
            db.Entry(Servicios).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Servicios Servicios)
        {
            db.Servicios.Remove(Servicios);
           
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
    #endregion
}
