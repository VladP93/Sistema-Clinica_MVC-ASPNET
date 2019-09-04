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
    public class SecretariasController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Secretarias
        public ActionResult Index()
        {
            var secretarias = db.Secretarias.Include(s => s.Usuario);
            return View(secretarias.ToList());
        }

        // GET: Secretarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // GET: Secretarias/Create
        public ActionResult Create()
        {
            ViewBag.sec_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario");
            return View();
        }

        // POST: Secretarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sec_idSecretaria,sec_nombre,sec_apellido,sec_idUsuario,sec_telefono,sec_direccion,sec_FechaNacimiento")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Secretarias.Add(secretaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sec_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", secretaria.sec_idUsuario);
            return View(secretaria);
        }

        // GET: Secretarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.sec_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", secretaria.sec_idUsuario);
            return View(secretaria);
        }

        // POST: Secretarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sec_idSecretaria,sec_nombre,sec_apellido,sec_idUsuario,sec_telefono,sec_direccion,sec_FechaNacimiento")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sec_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", secretaria.sec_idUsuario);
            return View(secretaria);
        }

        // GET: Secretarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secretaria secretaria = db.Secretarias.Find(id);
            db.Secretarias.Remove(secretaria);
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
