//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Clinica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HorarioConsulta
    {
        public int hor_idHorarioConsulta { get; set; }
        public int hor_idMedico { get; set; }
        public string hor_dia { get; set; }
        public string hor_horario { get; set; }
    
        public virtual Medico Medico { get; set; }
    }
}
