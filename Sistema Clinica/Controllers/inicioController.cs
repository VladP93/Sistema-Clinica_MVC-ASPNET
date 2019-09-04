using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Clinica.Models;

namespace Sistema_Clinica.Controllers
{

    public class inicioController : Controller
    {
        

        ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();
        // GET: inicio
        public ActionResult Index()
        {

            Session["tipoUsuario"] = 0;
            /*
            this.Session["tipoUsuario"] = 6;
            int tipoUsuario = Int32.Parse(Session["tipoUsuario"].ToString());

            var rutasRol = (from rxr in db.RutaRols
                            join rut in db.Rutas on rxr.rxr_idRuta equals rut.rut_idRuta
                            join rol in db.Rols on rxr.rxr_idRol equals rol.rol_idRol
                            where rxr.rxr_idRol == tipoUsuario
                            select new
                            {
                                nombreRuta = rut.rut_nombre,
                                ruta = rut.rut_ruta
                            }).ToList().Select(c => new rutasRoles
                            {
                                nombreRuta = c.nombreRuta,
                                ruta = c.ruta
                            });
*/
            //ViewData["listaRutas"] = rutasRol;
            return View();
        }
    }
}