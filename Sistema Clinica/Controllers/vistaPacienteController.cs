using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Clinica.Models;

namespace Sistema_Clinica.Controllers
{
    public class vistaPacienteController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();

        // GET: vistaPaciente
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult DetallesParaPaciente(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var citas = (from listaCitas in db.Citas
                         join meds in db.Medicos
                         on listaCitas.cit_idMedico equals meds.med_idMedico
                         where listaCitas.cit_idPaciente == id
                         select new
                         {
                             ddFechaCita = listaCitas.cit_fechaCita,
                             ddMedNombre = meds.med_nombre,
                             ddMedApellido = meds.med_apellido,
                             ddHoraCita = listaCitas.cit_horaCita
                         }).ToList()
                        .Select(c => new VistaPacientes
                        {
                            clFechaCita = c.ddFechaCita,
                            clMedNombre = c.ddMedNombre,
                            clMedApellido = c.ddMedApellido,
                            clHoraCita = c.ddHoraCita
                        });
            if (citas == null)
            {
                return HttpNotFound();
            }

            return View(citas);

        }

    }
}