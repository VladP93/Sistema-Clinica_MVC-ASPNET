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
    public class MedicosEspecialidadesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: MedicosEspecialidades
        public ActionResult Index()
        {
            var medicoEspecialidads = db.MedicoEspecialidads.Include(m => m.Especialidad).Include(m => m.Medico);
            return View(medicoEspecialidads.ToList());
        }

        // GET: MedicosEspecialidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidads.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(medicoEspecialidad);
        }

        // GET: MedicosEspecialidades/Create
        public ActionResult Create()
        {
            ViewBag.mes_idEspecialidad = new SelectList(db.Especialidads, "esp_idEspecialidad", "esp_Especialidad");
            ViewBag.mes_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre");
            return View();
        }

        // POST: MedicosEspecialidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mes_idMedicoEspecialidad,mes_idMedico,mes_idEspecialidad")] MedicoEspecialidad medicoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.MedicoEspecialidads.Add(medicoEspecialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mes_idEspecialidad = new SelectList(db.Especialidads, "esp_idEspecialidad", "esp_Especialidad", medicoEspecialidad.mes_idEspecialidad);
            ViewBag.mes_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", medicoEspecialidad.mes_idMedico);
            return View(medicoEspecialidad);
        }

        // GET: MedicosEspecialidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidads.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.mes_idEspecialidad = new SelectList(db.Especialidads, "esp_idEspecialidad", "esp_Especialidad", medicoEspecialidad.mes_idEspecialidad);
            ViewBag.mes_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", medicoEspecialidad.mes_idMedico);
            return View(medicoEspecialidad);
        }

        // POST: MedicosEspecialidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mes_idMedicoEspecialidad,mes_idMedico,mes_idEspecialidad")] MedicoEspecialidad medicoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicoEspecialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mes_idEspecialidad = new SelectList(db.Especialidads, "esp_idEspecialidad", "esp_Especialidad", medicoEspecialidad.mes_idEspecialidad);
            ViewBag.mes_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", medicoEspecialidad.mes_idMedico);
            return View(medicoEspecialidad);
        }

        // GET: MedicosEspecialidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidads.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(medicoEspecialidad);
        }

        // POST: MedicosEspecialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidads.Find(id);
            db.MedicoEspecialidads.Remove(medicoEspecialidad);
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
