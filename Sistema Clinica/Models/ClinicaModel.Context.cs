﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinicaPOO2018Entities : DbContext
    {
        public ClinicaPOO2018Entities()
            : base("name=ClinicaPOO2018Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Examan> Examen { get; set; }
        public virtual DbSet<Historial> Historials { get; set; }
        public virtual DbSet<HorarioConsulta> HorarioConsultas { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<MedicoEspecialidad> MedicoEspecialidads { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<Resultado> Resultadoes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Ruta> Rutas { get; set; }
        public virtual DbSet<RutaRol> RutaRols { get; set; }
        public virtual DbSet<Secretaria> Secretarias { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleadoes { get; set; }
        public virtual DbSet<TipoPaciente> TipoPacientes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
