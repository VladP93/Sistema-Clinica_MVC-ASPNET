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
    public class TiposEmpleadosController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: TiposEmpleados
        public ActionResult Index()
        {
            return View(db.TipoEmpleadoes.ToList());
        }

        // GET: TiposEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleadoes.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // GET: TiposEmpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tem_idTipoEmpleado,tem_tipo")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.TipoEmpleadoes.Add(tipoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEmpleado);
        }

        // GET: TiposEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleadoes.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TiposEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tem_idTipoEmpleado,tem_tipo")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEmpleado);
        }

        // GET: TiposEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleadoes.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TiposEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEmpleado tipoEmpleado = db.TipoEmpleadoes.Find(id);
            db.TipoEmpleadoes.Remove(tipoEmpleado);
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
