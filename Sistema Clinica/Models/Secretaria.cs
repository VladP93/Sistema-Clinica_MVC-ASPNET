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
    
    public partial class Secretaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Secretaria()
        {
            this.Medicos = new HashSet<Medico>();
        }
    
        public int sec_idSecretaria { get; set; }
        public string sec_nombre { get; set; }
        public string sec_apellido { get; set; }
        public Nullable<int> sec_idUsuario { get; set; }
        public string sec_telefono { get; set; }
        public string sec_direccion { get; set; }
        public Nullable<System.DateTime> sec_FechaNacimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
