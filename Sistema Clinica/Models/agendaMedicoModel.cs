using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Clinica.Models
{
    public class agendaMedicoModel
    {
        public int clPacIdPac { get; set; }
        public string clPacNombre { get; set; }
        public string clPacApellido { get; set; }
        public TimeSpan clHoraCita { get; set; }
        public bool clCitaEfectuada { get; set; }
        
    }
}