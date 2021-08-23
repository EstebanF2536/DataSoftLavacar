using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DataAccess.Services;

namespace Business.Logic
{
    #region MethodsLogicServicios
    public class ServiciosLogic
    {
        private ServiciosService sv = new ServiciosService();

        public List<Servicios> Index()
        {
            return sv.List();
        }

        public bool Exist(int id)
        {
            return sv.Find(id) != null;
        }

        public bool HaveCarro(int id)
        {
            return sv.HaveCarro(id);
        }

        public Servicios Get(int id)
        {
            return sv.Find(id);
        }

        public void Add(Servicios Servicios)
        {
            sv.Add(Servicios);
        }

        public void Edit(Servicios Servicios)
        {
            sv.Edit(Servicios);
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
