﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBoxManager.Data;

namespace SBoxManager.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.HistorialDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Creado");

                    b.Property<string>("CreadoPor");

                    b.Property<string>("Detalles")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Eliminado");

                    b.Property<string>("EliminadoPor");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("Modificado");

                    b.Property<string>("ModificadoPor");

                    b.Property<int>("PacienteHistorialId");

                    b.Property<string>("Titulo")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("PacienteHistorialId")
                        .IsUnique();

                    b.ToTable("HitorialDetalles");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Creado");

                    b.Property<string>("CreadoPor");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255);

                    b.Property<int>("Edad");

                    b.Property<DateTime?>("Eliminado");

                    b.Property<string>("EliminadoPor");

                    b.Property<string>("Foto");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("Modificado");

                    b.Property<string>("ModificadoPor");

                    b.Property<string>("Ocupacion")
                        .HasMaxLength(128);

                    b.Property<int>("PersonaId");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.PacienteHistorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alergicos");

                    b.Property<string>("Antecedentes")
                        .HasMaxLength(255);

                    b.Property<bool>("Aspirina");

                    b.Property<bool>("Cirugia");

                    b.Property<bool>("ConsumAlcohol");

                    b.Property<bool>("ConsumeMedic");

                    b.Property<DateTime?>("Creado");

                    b.Property<string>("CreadoPor");

                    b.Property<string>("DetalleUltimaConsulta")
                        .HasMaxLength(255);

                    b.Property<bool>("DiabetesMellitus");

                    b.Property<DateTime?>("Eliminado");

                    b.Property<string>("EliminadoPor");

                    b.Property<bool>("Embarazada");

                    b.Property<DateTime>("FechaUltimaConsulta");

                    b.Property<bool>("FiebreReumatica");

                    b.Property<bool>("Fuma");

                    b.Property<bool>("Gastrointestinales");

                    b.Property<bool>("Habitos");

                    b.Property<bool>("Hepaticos");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Medico");

                    b.Property<DateTime?>("Modificado");

                    b.Property<string>("ModificadoPor");

                    b.Property<string>("Motivo")
                        .HasMaxLength(255);

                    b.Property<string>("MotivoCirugia");

                    b.Property<int>("PacienteId");

                    b.Property<bool>("Penicilina");

                    b.Property<bool>("PresionArterial");

                    b.Property<bool>("ProbAnestesia");

                    b.Property<string>("ProblemasAnteriores")
                        .HasMaxLength(255);

                    b.Property<bool>("Pulmonales");

                    b.Property<bool>("RenalesGenitales");

                    b.Property<bool>("Sanguineos");

                    b.Property<string>("Tratamiento")
                        .HasMaxLength(255);

                    b.Property<bool>("Venereas");

                    b.Property<bool>("VihSida");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("PacienteHistoriales");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasMaxLength(128);

                    b.Property<Guid>("Codigo")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("Creado");

                    b.Property<string>("CreadoPor");

                    b.Property<DateTime>("DoB");

                    b.Property<DateTime?>("Eliminado");

                    b.Property<string>("EliminadoPor");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("Modificado");

                    b.Property<string>("ModificadoPor");

                    b.Property<string>("Nombre")
                        .HasMaxLength(96);

                    b.Property<int>("Sexo");

                    b.Property<string>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.Telefonos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Creado");

                    b.Property<string>("CreadoPor");

                    b.Property<string>("Detalles");

                    b.Property<DateTime?>("Eliminado");

                    b.Property<string>("EliminadoPor");

                    b.Property<bool>("IsDelete");

                    b.Property<DateTime?>("Modificado");

                    b.Property<string>("ModificadoPor");

                    b.Property<string>("Numero");

                    b.Property<int>("PersonaId");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("SBoxManager.Data.EntidadUsuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SBoxManager.Data.EntidadUsuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SBoxManager.Data.EntidadUsuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBoxManager.Data.EntidadUsuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SBoxManager.Data.EntidadUsuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.HistorialDetalle", b =>
                {
                    b.HasOne("SBoxManager.Data.DTOs.ODO.PacienteHistorial", "PacienteHistorial")
                        .WithOne("Detalles")
                        .HasForeignKey("SBoxManager.Data.DTOs.ODO.HistorialDetalle", "PacienteHistorialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.Paciente", b =>
                {
                    b.HasOne("SBoxManager.Data.DTOs.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.ODO.PacienteHistorial", b =>
                {
                    b.HasOne("SBoxManager.Data.DTOs.ODO.Paciente", "Paciente")
                        .WithMany("Historiales")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.Persona", b =>
                {
                    b.HasOne("SBoxManager.Data.EntidadUsuario", "Usuario")
                        .WithOne("Persona")
                        .HasForeignKey("SBoxManager.Data.DTOs.Persona", "UsuarioId");
                });

            modelBuilder.Entity("SBoxManager.Data.DTOs.Telefonos", b =>
                {
                    b.HasOne("SBoxManager.Data.DTOs.Persona", "Persona")
                        .WithMany("Telefonos")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
