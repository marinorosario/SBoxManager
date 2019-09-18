using Microsoft.EntityFrameworkCore.Migrations;

namespace SBoxManager.Data.Migrations
{
    public partial class pacientepersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Pacientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PersonaId",
                table: "Pacientes",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Personas_PersonaId",
                table: "Pacientes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Personas_PersonaId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PersonaId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Pacientes");
        }
    }
}
