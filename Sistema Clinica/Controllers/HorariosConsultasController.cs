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
    public class HorariosConsultasController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: HorariosConsultas
        public ActionResult Index()
        {
            var horarioConsultas = db.HorarioConsultas.Include(h => h.Medico);
            return View(horarioConsultas.ToList());
        }

        // GET: HorariosConsultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioConsulta horarioConsulta = db.HorarioConsultas.Find(id);
            if (horarioConsulta == null)
            {
                return HttpNotFound();
            }
            return View(horarioConsulta);
        }

        // GET: HorariosConsultas/Create
        public ActionResult Create()
        {
            ViewBag.hor_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre");
            return View();
        }

        // POST: HorariosConsultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hor_idHorarioConsulta,hor_idMedico,hor_dia,hor_horario")] HorarioConsulta horarioConsulta)
        {
            if (ModelState.IsValid)
            {
                db.HorarioConsultas.Add(horarioConsulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hor_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", horarioConsulta.hor_idMedico);
            return View(horarioConsulta);
        }

        // GET: HorariosConsultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioConsulta horarioConsulta = db.HorarioConsultas.Find(id);
            if (horarioConsulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.hor_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", horarioConsulta.hor_idMedico);
            return View(horarioConsulta);
        }

        // POST: HorariosConsultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hor_idHorarioConsulta,hor_idMedico,hor_dia,hor_horario")] HorarioConsulta horarioConsulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarioConsulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hor_idMedico = new SelectList(db.Medicos, "med_idMedico", "med_nombre", horarioConsulta.hor_idMedico);
            return View(horarioConsulta);
        }

        // GET: HorariosConsultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioConsulta horarioConsulta = db.HorarioConsultas.Find(id);
            if (horarioConsulta == null)
            {
                return HttpNotFound();
            }
            return View(horarioConsulta);
        }

        // POST: HorariosConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioConsulta horarioConsulta = db.HorarioConsultas.Find(id);
            db.HorarioConsultas.Remove(horarioConsulta);
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
