using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Clinica.Models;

namespace Sistema_Clinica.Controllers
{
    public class HistorialesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Historiales
        public ActionResult Index()
        {
            var historials = db.Historials.Include(h => h.Paciente);
            return View(historials.ToList());
        }

        // GET: Historiales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // GET: Historiales/Create
        public ActionResult Create()
        {
            ViewBag.his_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre");
            return View();
        }

        // POST: Historiales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "his_idHistorial,his_idPaciente,his_fecha,his_contenido")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Historials.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.his_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", historial.his_idPaciente);
            return View(historial);
        }

        // GET: Historiales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            ViewBag.his_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", historial.his_idPaciente);
            return View(historial);
        }

        // POST: Historiales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "his_idHistorial,his_idPaciente,his_fecha,his_contenido")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.his_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", historial.his_idPaciente);
            return View(historial);
        }

        // GET: Historiales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: Historiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historial historial = db.Historials.Find(id);
            db.Historials.Remove(historial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
