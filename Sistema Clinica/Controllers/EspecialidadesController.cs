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
    public class EspecialidadesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Especialidades
        public ActionResult Index()
        {
            return View(db.Especialidads.ToList());
        }

        // GET: Especialidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // GET: Especialidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "esp_idEspecialidad,esp_Especialidad")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Especialidads.Add(especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: Especialidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "esp_idEspecialidad,esp_Especialidad")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: Especialidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidad especialidad = db.Especialidads.Find(id);
            db.Especialidads.Remove(especialidad);
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
