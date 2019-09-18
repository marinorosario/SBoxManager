using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBoxManager.Data.Migrations
{
    public partial class personaauditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creado",
                table: "Personas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Eliminado",
                table: "Personas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EliminadoPor",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Personas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modificado",
                table: "Personas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPor",
                table: "Personas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EliminadoPor",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Modificado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ModificadoPor",
                table: "Personas");
        }
    }
}
