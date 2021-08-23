using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business.Logic;
using Entities.Models;

namespace Application.Controllers
{
    #region ControllerVehiculo_Servicio
    public class Vehiculo_ServicioController : Controller
    {
        private Vehiculo_ServicioLogic lg = new Vehiculo_ServicioLogic();
        private ServiciosLogic lgs = new ServiciosLogic();

        // GET: Vehiculo_Servicio/Create
        public ActionResult Create()
        {
            return View(lgs.Index());
        }

        // POST: Vehiculo_Servicio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vehiculo_servicio,id_servicio,id_vehiculo")] Vehiculo_Servicio vehiculo_Servicio)
        {
            string placa = Request["txtplaca"].ToString();
            int id_servicio = int.Parse(Request.Form["selectServicios"]);

            if (!lg.PlacaExist(placa))
            {
                TempData["message"] = "Error, la placa digitada no existe";
                return RedirectToAction("Create", "Vehiculo_Servicio");
            }

            int id_vehiculo = lg.GetID(placa);

            lg.Add(new Vehiculo_Servicio() { id_servicio = id_servicio, id_vehiculo = id_vehiculo });
            TempData["message"] = "Asignacion completada";
            return RedirectToAction("Create");
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

