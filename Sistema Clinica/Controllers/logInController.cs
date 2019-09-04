using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Clinica.Models;

namespace Sistema_Clinica.Controllers
{
    public class logInController : Controller
    {
        private ClinicaPOO2018Entities db = new ClinicaPOO2018Entities();
        // GET: logIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticacion(string usuario, string pass)
        {
            string nombre; 

            var rol = (from u in db.Usuarios
                       where u.usu_usuario == usuario
                       && u.usu_contrasena == pass
                       select u.usu_idRol).ToArray();


            if (rol.Length == 1)
            {
                Session["tipoUsuario"] = rol[0];

                if (rol[0] == 2)
                {
                    var nombreUsuario = (from u in db.Usuarios
                                         join meds in db.Medicos on u.usu_idUsuario equals meds.med_idUsuario
                                         where u.usu_usuario == usuario
                                         && u.usu_contrasena == pass
                                         select meds.med_nombre).ToArray();
                    var idUsu = (from u in db.Usuarios
                                 join meds in db.Medicos on u.usu_idUsuario equals meds.med_idUsuario
                                 where u.usu_usuario == usuario
                                 && u.usu_contrasena == pass
                                 select meds.med_idMedico).ToArray();
                    Session["idUsu"] = idUsu;
                    nombre = nombreUsuario[0];
                    ViewData["nombreUsuario"] = "doctor " + nombre;
                    return RedirectToAction("AgendaParaMedico/" + idUsu[0], "Medicos");
                }
                if (rol[0] == 3)
                {
                    var nombreUsuario = (from u in db.Usuarios
                                         join secs in db.Secretarias on u.usu_idUsuario equals secs.sec_idUsuario
                                         where u.usu_usuario == usuario
                                         && u.usu_contrasena == pass
                                         select secs.sec_nombre).ToArray();
                    var idUsu = (from u in db.Usuarios
                                 join secs in db.Secretarias on u.usu_idUsuario equals secs.sec_idUsuario
                                 where u.usu_usuario == usuario
                                 && u.usu_contrasena == pass
                                 select secs.sec_idSecretaria).ToArray();
                    Session["idUsu"] = idUsu;
                    nombre = nombreUsuario[0];
                    ViewData["nombreUsuario"] = "señorita " + nombre;
                    return View();
                }
                if (rol[0] == 4)
                {
                    var nombreUsuario = (from u in db.Usuarios
                                         join pacs in db.Pacientes on u.usu_idUsuario equals pacs.pac_idUsuario
                                         where u.usu_usuario == usuario
                                         && u.usu_contrasena == pass
                                         select pacs.pac_nombre).ToArray();
                    var idUsu = (from u in db.Usuarios
                                 join pacs in db.Pacientes on u.usu_idUsuario equals pacs.pac_idUsuario
                                 where u.usu_usuario == usuario
                                 && u.usu_contrasena == pass
                                 select pacs.pac_idPaciente).ToArray();
                    Session["idUsu"] = idUsu;
                    nombre = nombreUsuario[0];
                    Session["nombreUsuario"] = "querido/a paciente " + nombre;
                    return RedirectToAction("DetallesParaPaciente/" + idUsu[0], "vistaPaciente");
                }
                if (rol[0] != 2 && rol[0] != 3 && rol[0] != 4)
                {
                    var nombreUsuario = (from u in db.Usuarios
                                         join emps in db.Empleadoes on u.usu_idUsuario equals emps.emp_idUsuario
                                         where u.usu_usuario == usuario
                                         && u.usu_contrasena == pass
                                         select emps.emp_nombre).ToArray();
                    var idUsu = (from u in db.Usuarios
                                 join emps in db.Empleadoes on u.usu_idUsuario equals emps.emp_idUsuario
                                 where u.usu_usuario == usuario
                                 && u.usu_contrasena == pass
                                 select emps.emp_idEmpleado).ToArray();
                    Session["idUsu"] = idUsu;
                    nombre = nombreUsuario[0];
                    ViewData["nombreUsuario"] = "estimado/a " + nombre;
                    return View();
                }
                else
                {
                    return View("UserNotFound");
                }
            } else
            {
                return View("UserNotFound");
            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult UserNotFound()
        {
            return View();
        }

        public ActionResult Registrar(string usuario, string pass, string nombre, string apellido, string dui, string sexo, string telefono, string direccion, string fechaNac)
        {
            Usuario user = new Usuario { usu_usuario = usuario, usu_contrasena = pass, usu_idRol = 4 };
            db.Usuarios.Add(user);
            db.SaveChanges();

            var noUsuario = (from u in db.Usuarios
                            where u.usu_usuario == usuario
                            select u.usu_idUsuario).ToArray();

            Paciente pac = new Paciente
            {
                pac_nombre = nombre,
                pac_apellido = apellido,
                pac_idTipoPaciente = 1,
                pac_DUI = dui,
                pac_sexo = sexo,
                pac_telefono = telefono,
                pac_direccion = direccion,
                pac_fechaNacimiento = DateTime.ParseExact(fechaNac, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                pac_visible = true,
                pac_idUsuario = noUsuario[0]
            };
            db.Pacientes.Add(pac);
            db.SaveChanges();

            return View("Index");
        }
    }
}