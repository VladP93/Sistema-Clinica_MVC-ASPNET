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
    public class ExamenesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Examenes
        public ActionResult Index()
        {
            var examen = db.Examen.Include(e => e.Empleado).Include(e => e.Historial).Include(e => e.Resultado);
            return View(examen.ToList());
        }

        // GET: Examenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // GET: Examenes/Create
        public ActionResult Create()
        {
            ViewBag.exm_idEmpleado = new SelectList(db.Empleadoes, "emp_idEmpleado", "emp_nombre");
            ViewBag.exm_idHistorial = new SelectList(db.Historials, "his_idHistorial", "his_idHistorial");
            ViewBag.exm_idResultado = new SelectList(db.Resultadoes, "res_idResultado", "res_resultado");
            return View();
        }

        // POST: Examenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exm_idExamen,exm_idHistorial,exm_idEmpleado,exm_idResultado")] Examan examan)
        {
            if (ModelState.IsValid)
            {
                db.Examen.Add(examan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exm_idEmpleado = new SelectList(db.Empleadoes, "emp_idEmpleado", "emp_nombre", examan.exm_idEmpleado);
            ViewBag.exm_idHistorial = new SelectList(db.Historials, "his_idHistorial", "his_idHistorial", examan.exm_idHistorial);
            ViewBag.exm_idResultado = new SelectList(db.Resultadoes, "res_idResultado", "res_resultado", examan.exm_idResultado);
            return View(examan);
        }

        // GET: Examenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            ViewBag.exm_idEmpleado = new SelectList(db.Empleadoes, "emp_idEmpleado", "emp_nombre", examan.exm_idEmpleado);
            ViewBag.exm_idHistorial = new SelectList(db.Historials, "his_idHistorial", "his_idHistorial", examan.exm_idHistorial);
            ViewBag.exm_idResultado = new SelectList(db.Resultadoes, "res_idResultado", "res_resultado", examan.exm_idResultado);
            return View(examan);
        }

        // POST: Examenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exm_idExamen,exm_idHistorial,exm_idEmpleado,exm_idResultado")] Examan examan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exm_idEmpleado = new SelectList(db.Empleadoes, "emp_idEmpleado", "emp_nombre", examan.exm_idEmpleado);
            ViewBag.exm_idHistorial = new SelectList(db.Historials, "his_idHistorial", "his_idHistorial", examan.exm_idHistorial);
            ViewBag.exm_idResultado = new SelectList(db.Resultadoes, "res_idResultado", "res_resultado", examan.exm_idResultado);
            return View(examan);
        }

        // GET: Examenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // POST: Examenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examan examan = db.Examen.Find(id);
            db.Examen.Remove(examan);
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
