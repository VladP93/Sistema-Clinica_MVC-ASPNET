using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Clinica.Models
{
    public class VistaPacientes
    {
        public DateTime clFechaCita { get; set; }
        public string clMedNombre { get; set; }
        public string clMedApellido { get; set; }
        public TimeSpan clHoraCita { get; set; }
    }
}