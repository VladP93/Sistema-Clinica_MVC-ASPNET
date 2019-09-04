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
    public class MedicosController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();


        public ActionResult AgendaParaMedico(int? id)
        {
            var citas = (from listaCitas in db.Citas
                         join pacs in db.Pacientes
                         on listaCitas.cit_idPaciente equals pacs.pac_idPaciente
                         where listaCitas.cit_idMedico == id
                         select new
                         {
                             ddPacIdPac = pacs.pac_idPaciente,
                             ddPacNombre = pacs.pac_nombre,
                             ddPacApellido = pacs.pac_apellido,
                             ddHoraCita = listaCitas.cit_horaCita,
                             ddCitaEfectuada = listaCitas.cit_consultaEfectuada,
                         }).ToList()
                        .Select(c => new agendaMedicoModel
                        {
                            clPacIdPac = c.ddPacIdPac,
                            clPacNombre = c.ddPacNombre,
                            clPacApellido = c.ddPacApellido,
                            clCitaEfectuada = c.ddCitaEfectuada,
                            clHoraCita = c.ddHoraCita
                        });
            
            return View(citas);

        }

        public ActionResult AgendaParaMedicoDia(string dia, string mes, string anno)
        {
            int id = Int32.Parse(Session["idUsu"].ToString());
            int diaf = int.Parse(dia);
            int mesf = int.Parse(mes);
            int annof = int.Parse(anno);
            DateTime fecha = Convert.ToDateTime(annof + "-" + mesf + "-" + diaf);
            var citas = (from listaCitas in db.Citas
                         join pacs in db.Pacientes
                         on listaCitas.cit_idPaciente equals pacs.pac_idPaciente
                         where listaCitas.cit_idMedico == id
                         && listaCitas.cit_fechaCita == fecha
                         select new
                         {
                             ddPacIdPac = pacs.pac_idPaciente,
                             ddPacNombre = pacs.pac_nombre,
                             ddPacApellido = pacs.pac_apellido,
                             ddHoraCita = listaCitas.cit_horaCita,
                             ddCitaEfectuada = listaCitas.cit_consultaEfectuada,
                         }).ToList()
                        .Select(c => new agendaMedicoModel
                        {
                            clPacIdPac = c.ddPacIdPac,
                            clPacNombre = c.ddPacNombre,
                            clPacApellido = c.ddPacApellido,
                            clCitaEfectuada = c.ddCitaEfectuada,
                            clHoraCita = c.ddHoraCita
                        });
            return View(citas);

        }


        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Secretaria).Include(m => m.Usuario);
            return View(medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.med_idSecretaria = new SelectList(db.Secretarias, "sec_idSecretaria", "sec_nombre");
            ViewBag.med_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario");
            return View();
        }

        // POST: Medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "med_idMedico,med_idSecretaria,med_nombre,med_apellido,med_idUsuario,med_telefono,med_direccion,med_jvpm,med_precioConsulta")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.med_idSecretaria = new SelectList(db.Secretarias, "sec_idSecretaria", "sec_nombre", medico.med_idSecretaria);
            ViewBag.med_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", medico.med_idUsuario);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.med_idSecretaria = new SelectList(db.Secretarias, "sec_idSecretaria", "sec_nombre", medico.med_idSecretaria);
            ViewBag.med_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", medico.med_idUsuario);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "med_idMedico,med_idSecretaria,med_nombre,med_apellido,med_idUsuario,med_telefono,med_direccion,med_jvpm,med_precioConsulta")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.med_idSecretaria = new SelectList(db.Secretarias, "sec_idSecretaria", "sec_nombre", medico.med_idSecretaria);
            ViewBag.med_idUsuario = new SelectList(db.Usuarios, "usu_idUsuario", "usu_usuario", medico.med_idUsuario);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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
