using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using Business.Logic;
using Entities.VehiculoListViewModel;

namespace Application.Controllers
{
    #region ControllerVehiculo
    public class VehiculoController : Controller
    {
        private VehiculoLogic lg = new VehiculoLogic();
        private Vehiculo_ServicioLogic vehiculoServicioObj = new Vehiculo_ServicioLogic();

        // GET: Vehiculo
        public ActionResult Index(int? id_servicio)
        {
            VehiculoListViewModel objeto = new VehiculoListViewModel();

            objeto.VehiculosList = lg.Index(id_servicio);
            objeto.IdServicio = id_servicio;

            return View(objeto);

        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!lg.Exist((int)id))
            {
                return HttpNotFound();
            }
            return View(lg.Get((int)id));
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vehiculo,placa,dueño,marca")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                lg.Add(vehiculo);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!lg.Exist((int)id))
            {
                return HttpNotFound();
            }
            return View(lg.Get((int)id));
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vehiculo,placa,dueño,marca")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                lg.Edit(vehiculo);
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }
        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id, int? idServicio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!lg.Exist((int)id))
            {
                return HttpNotFound();
            }

            if (idServicio == null)
            {
                if (lg.HaveService((int)id))
                {
                    TempData["message"] = "Error, no puede eliminar un vehiculo que posea servicios";
                    return RedirectToAction("Index", "Vehiculo");
                }
            }

            

            return View(lg.Get((int)id));
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? idServicio)
        {
            if (idServicio == null)
                lg.Delete(id);
            else
                vehiculoServicioObj.Delete(id, idServicio);

            return RedirectToAction("Index", "Servicios");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lg.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    #endregion
}
