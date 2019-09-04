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
    public class EmpleadosController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Cargo).Include(e => e.TipoEmpleado).Include(e => e.Usuario);
            return View(empleadoes.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.emp_idCargo = new SelectList(db.Cargoes, "car_idCargo", "car_cargo");
            ViewBag.emp_idTipoEmpleado = new SelectList(db.TipoEmpleadoes, "tem_idTipoEmpleado", "tem_tipo");
            ViewBag.emp_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_idEmpleado,emp_idTipoEmpleado,emp_nombre,emp_apellido,emp_idUsuario,emp_fechaNacimiento,emp_telefono,emp_idCargo,emp_dui")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_idCargo = new SelectList(db.Cargoes, "car_idCargo", "car_cargo", empleado.emp_idCargo);
            ViewBag.emp_idTipoEmpleado = new SelectList(db.TipoEmpleadoes, "tem_idTipoEmpleado", "tem_tipo", empleado.emp_idTipoEmpleado);
            ViewBag.emp_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", empleado.emp_idUsuario);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_idCargo = new SelectList(db.Cargoes, "car_idCargo", "car_cargo", empleado.emp_idCargo);
            ViewBag.emp_idTipoEmpleado = new SelectList(db.TipoEmpleadoes, "tem_idTipoEmpleado", "tem_tipo", empleado.emp_idTipoEmpleado);
            ViewBag.emp_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", empleado.emp_idUsuario);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_idEmpleado,emp_idTipoEmpleado,emp_nombre,emp_apellido,emp_idUsuario,emp_fechaNacimiento,emp_telefono,emp_idCargo,emp_dui")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_idCargo = new SelectList(db.Cargoes, "car_idCargo", "car_cargo", empleado.emp_idCargo);
            ViewBag.emp_idTipoEmpleado = new SelectList(db.TipoEmpleadoes, "tem_idTipoEmpleado", "tem_tipo", empleado.emp_idTipoEmpleado);
            ViewBag.emp_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", empleado.emp_idUsuario);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
