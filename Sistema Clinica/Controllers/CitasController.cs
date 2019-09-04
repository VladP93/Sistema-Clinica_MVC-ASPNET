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
    public class CitasController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.cit_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre");
            ViewBag.cit_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cit_idCita,cit_idMedico,cit_idPaciente,cit_fechaCreacion,cit_fechaCita,cit_horaCita,cit_consultaEfectuada,cit_examenprogramado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cit_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", cita.cit_idMedico);
            ViewBag.cit_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", cita.cit_idPaciente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.cit_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", cita.cit_idMedico);
            ViewBag.cit_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", cita.cit_idPaciente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cit_idCita,cit_idMedico,cit_idPaciente,cit_fechaCreacion,cit_fechaCita,cit_horaCita,cit_consultaEfectuada,cit_examenprogramado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cit_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", cita.cit_idMedico);
            ViewBag.cit_idPaciente = new SelectList(db.Pacientes, "pac_idPaciente", "pac_nombre", cita.cit_idPaciente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Citas.Find(id);
            db.Citas.Remove(cita);
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
