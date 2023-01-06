using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_ef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Decripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Decripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Decripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c191"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Tema", "Titulo" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc10"), new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), null, new DateTime(2023, 1, 6, 14, 23, 32, 889, DateTimeKind.Local).AddTicks(5670), 1, null, "Pago de Servicios Publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Tema", "Titulo" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc11"), new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c191"), null, new DateTime(2023, 1, 6, 14, 23, 32, 889, DateTimeKind.Local).AddTicks(5974), 0, null, "Terminar de ver serie de netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c191"));

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Decripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
