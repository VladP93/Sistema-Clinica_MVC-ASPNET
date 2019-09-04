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
    public class PacientesController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.TipoPaciente).Include(p => p.Usuario);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.pac_idTipoPaciente = new SelectList(db.TipoPacientes, "tpa_idTipoPaciente", "tpa_tipo");
            ViewBag.pac_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario");
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pac_idPaciente,pac_idTipoPaciente,pac_nombre,pac_apellido,pac_idUsuario,pac_DUI,pac_sexo,pac_telefono,pac_direccion,pac_fechaNacimiento,pac_visible")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pac_idTipoPaciente = new SelectList(db.TipoPacientes, "tpa_idTipoPaciente", "tpa_tipo", paciente.pac_idTipoPaciente);
            ViewBag.pac_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", paciente.pac_idUsuario);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.pac_idTipoPaciente = new SelectList(db.TipoPacientes, "tpa_idTipoPaciente", "tpa_tipo", paciente.pac_idTipoPaciente);
            ViewBag.pac_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", paciente.pac_idUsuario);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pac_idPaciente,pac_idTipoPaciente,pac_nombre,pac_apellido,pac_idUsuario,pac_DUI,pac_sexo,pac_telefono,pac_direccion,pac_fechaNacimiento,pac_visible")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pac_idTipoPaciente = new SelectList(db.TipoPacientes, "tpa_idTipoPaciente", "tpa_tipo", paciente.pac_idTipoPaciente);
            ViewBag.pac_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", paciente.pac_idUsuario);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
