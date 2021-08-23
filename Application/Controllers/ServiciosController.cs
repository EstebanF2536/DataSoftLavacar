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

namespace Application.Controllers
{
    #region ControllersServicios
    public class ServiciosController : Controller
    {
        private ServiciosLogic lg = new ServiciosLogic();
        // GET: Servicios
        public ActionResult Index()
        {
            return View(lg.Index());

        }
   
        // GET: Servicios/Details/5
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
     
     
        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_servicio,descripción,monto")] Servicios Servicios)
        {
            if (ModelState.IsValid)
            {
                lg.Add(Servicios);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        // GET: Servicios/Edit/5
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

        // POST: Servicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_servicio,descripción,monto")] Servicios Servicios)
        {
            if (ModelState.IsValid)
            {
                lg.Edit(Servicios);
                return RedirectToAction("Index");
            }
            return View(Servicios);
        }
        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!lg.Exist((int)id))
            {
                return HttpNotFound();
            }
            if (lg.HaveCarro((int)id))
            {
                TempData["message"] = "Error, no puede eliminar un Servicio que posea automoviles";
                return RedirectToAction("Index", "Servicios");
            }
            return View(lg.Get((int)id));
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lg.Delete(id);
            return RedirectToAction("Index");
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
