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
    
    public partial class RutaRol
    {
        public int rxr_idrxr { get; set; }
        public int rxr_idRol { get; set; }
        public int rxr_idRuta { get; set; }
    
        public virtual Rol Rol { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}