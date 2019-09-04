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
    public class RutasRolesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: RutasRoles
        public ActionResult Index()
        {
            var rutaRols = db.RutaRols.Include(r => r.Rol).Include(r => r.Ruta);
            return View(rutaRols.ToList());
        }

        // GET: RutasRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaRol rutaRol = db.RutaRols.Find(id);
            if (rutaRol == null)
            {
                return HttpNotFound();
            }
            return View(rutaRol);
        }

        // GET: RutasRoles/Create
        public ActionResult Create()
        {
            ViewBag.rxr_idRol = new SelectList(db.Rols, "rol_idRol", "rol_rol");
            ViewBag.rxr_idRuta = new SelectList(db.Rutas, "rut_idRuta", "rut_ruta");
            return View();
        }

        // POST: RutasRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rxr_idrxr,rxr_idRol,rxr_idRuta")] RutaRol rutaRol)
        {
            if (ModelState.IsValid)
            {
                db.RutaRols.Add(rutaRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rxr_idRol = new SelectList(db.Rols, "rol_idRol", "rol_rol", rutaRol.rxr_idRol);
            ViewBag.rxr_idRuta = new SelectList(db.Rutas, "rut_idRuta", "rut_ruta", rutaRol.rxr_idRuta);
            return View(rutaRol);
        }

        // GET: RutasRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaRol rutaRol = db.RutaRols.Find(id);
            if (rutaRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.rxr_idRol = new SelectList(db.Rols, "rol_idRol", "rol_rol", rutaRol.rxr_idRol);
            ViewBag.rxr_idRuta = new SelectList(db.Rutas, "rut_idRuta", "rut_ruta", rutaRol.rxr_idRuta);
            return View(rutaRol);
        }

        // POST: RutasRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rxr_idrxr,rxr_idRol,rxr_idRuta")] RutaRol rutaRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutaRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rxr_idRol = new SelectList(db.Rols, "rol_idRol", "rol_rol", rutaRol.rxr_idRol);
            ViewBag.rxr_idRuta = new SelectList(db.Rutas, "rut_idRuta", "rut_ruta", rutaRol.rxr_idRuta);
            return View(rutaRol);
        }

        // GET: RutasRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaRol rutaRol = db.RutaRols.Find(id);
            if (rutaRol == null)
            {
                return HttpNotFound();
            }
            return View(rutaRol);
        }

        // POST: RutasRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RutaRol rutaRol = db.RutaRols.Find(id);
            db.RutaRols.Remove(rutaRol);
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
