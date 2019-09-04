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
    public class TiposPacientesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: TiposPacientes
        public ActionResult Index()
        {
            return View(db.TipoPacientes.ToList());
        }

        // GET: TiposPacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPacientes.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // GET: TiposPacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposPacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tpa_idTipoPaciente,tpa_tipo")] TipoPaciente tipoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.TipoPacientes.Add(tipoPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPaciente);
        }

        // GET: TiposPacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPacientes.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // POST: TiposPacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tpa_idTipoPaciente,tpa_tipo")] TipoPaciente tipoPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPaciente);
        }

        // GET: TiposPacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPaciente tipoPaciente = db.TipoPacientes.Find(id);
            if (tipoPaciente == null)
            {
                return HttpNotFound();
            }
            return View(tipoPaciente);
        }

        // POST: TiposPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPaciente tipoPaciente = db.TipoPacientes.Find(id);
            db.TipoPacientes.Remove(tipoPaciente);
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
