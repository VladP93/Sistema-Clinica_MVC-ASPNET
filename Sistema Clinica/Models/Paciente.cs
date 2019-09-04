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
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.Citas = new HashSet<Cita>();
            this.Historials = new HashSet<Historial>();
        }
    
        public int pac_idPaciente { get; set; }
        public int pac_idTipoPaciente { get; set; }
        public string pac_nombre { get; set; }
        public string pac_apellido { get; set; }
        public Nullable<int> pac_idUsuario { get; set; }
        public string pac_DUI { get; set; }
        public string pac_sexo { get; set; }
        public string pac_telefono { get; set; }
        public string pac_direccion { get; set; }
        public Nullable<System.DateTime> pac_fechaNacimiento { get; set; }
        public bool pac_visible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Citas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial> Historials { get; set; }
        public virtual TipoPaciente TipoPaciente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
