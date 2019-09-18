using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBoxManager.Data.Migrations
{
    public partial class pacientehistorialdetallestelefonospersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Creado = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Eliminado = table.Column<DateTime>(nullable: false),
                    EliminadoPor = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Foto = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: true),
                    Ocupacion = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Creado = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Eliminado = table.Column<DateTime>(nullable: false),
                    EliminadoPor = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Detalles = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteHistoriales",
                columns: table => new
                {
                    Creado = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Eliminado = table.Column<DateTime>(nullable: false),
                    EliminadoPor = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Motivo = table.Column<string>(maxLength: 255, nullable: true),
                    Antecedentes = table.Column<string>(maxLength: 255, nullable: true),
                    FechaUltimaConsulta = table.Column<DateTime>(nullable: false),
                    DetalleUltimaConsulta = table.Column<string>(maxLength: 255, nullable: true),
                    ProblemasAnteriores = table.Column<string>(maxLength: 255, nullable: true),
                    Tratamiento = table.Column<string>(maxLength: 255, nullable: true),
                    Cirugia = table.Column<bool>(nullable: false),
                    MotivoCirugia = table.Column<string>(nullable: true),
                    Medico = table.Column<string>(nullable: true),
                    PresionArterial = table.Column<bool>(nullable: false),
                    RenalesGenitales = table.Column<bool>(nullable: false),
                    Gastrointestinales = table.Column<bool>(nullable: false),
                    Hepaticos = table.Column<bool>(nullable: false),
                    Pulmonales = table.Column<bool>(nullable: false),
                    DiabetesMellitus = table.Column<bool>(nullable: false),
                    FiebreReumatica = table.Column<bool>(nullable: false),
                    Sanguineos = table.Column<bool>(nullable: false),
                    Alergicos = table.Column<bool>(nullable: false),
                    ConsumeMedic = table.Column<bool>(nullable: false),
                    VihSida = table.Column<bool>(nullable: false),
                    Venereas = table.Column<bool>(nullable: false),
                    Fuma = table.Column<bool>(nullable: false),
                    ConsumAlcohol = table.Column<bool>(nullable: false),
                    Penicilina = table.Column<bool>(nullable: false),
                    Aspirina = table.Column<bool>(nullable: false),
                    ProbAnestesia = table.Column<bool>(nullable: false),
                    Habitos = table.Column<bool>(nullable: false),
                    Embarazada = table.Column<bool>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteHistoriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteHistoriales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HitorialDetalles",
                columns: table => new
                {
                    Creado = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(nullable: true),
                    Modificado = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Eliminado = table.Column<DateTime>(nullable: false),
                    EliminadoPor = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(maxLength: 128, nullable: true),
                    Detalles = table.Column<string>(maxLength: 255, nullable: true),
                    PacienteHistorialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitorialDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HitorialDetalles_PacienteHistoriales_PacienteHistorialId",
                        column: x => x.PacienteHistorialId,
                        principalTable: "PacienteHistoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HitorialDetalles_PacienteHistorialId",
                table: "HitorialDetalles",
                column: "PacienteHistorialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacienteHistoriales_PacienteId",
                table: "PacienteHistoriales",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_PersonaId",
                table: "Telefonos",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HitorialDetalles");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "PacienteHistoriales");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
