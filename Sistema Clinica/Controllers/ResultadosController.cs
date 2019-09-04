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
    public class ResultadosController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Resultados
        public ActionResult Index()
        {
            return View(db.Resultadoes.ToList());
        }

        // GET: Resultados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultadoes.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // GET: Resultados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resultados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "res_idResultado,res_resultado")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Resultadoes.Add(resultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultado);
        }

        // GET: Resultados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultadoes.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "res_idResultado,res_resultado")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultado);
        }

        // GET: Resultados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultadoes.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultado resultado = db.Resultadoes.Find(id);
            db.Resultadoes.Remove(resultado);
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
