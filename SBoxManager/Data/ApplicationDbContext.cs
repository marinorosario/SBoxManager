using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBoxManager.Data.DTOs;
using SBoxManager.Data.DTOs.ODO;

namespace SBoxManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<EntidadUsuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Persona>().HasQueryFilter(p => p.IsDelete.Equals(false));

            builder.Entity<EntidadUsuario>()
                .HasOne(eu => eu.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Persona>(p => p.UsuarioId);

            
            base.OnModelCreating(builder);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefonos> Telefonos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteHistorial>  PacienteHistoriales { get; set; }
        public DbSet<HistorialDetalle> HitorialDetalles { get; set; }


    }
}
