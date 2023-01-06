using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_ef.Migrations
{
    public partial class SecondData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Decripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c192"), null, "Actividades Laborales", 90 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc10"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 6, 14, 28, 51, 430, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc11"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 6, 14, 28, 51, 430, DateTimeKind.Local).AddTicks(4390));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Tema", "Titulo" },
                values: new object[] { new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc12"), new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), null, new DateTime(2023, 1, 6, 14, 28, 51, 430, DateTimeKind.Local).AddTicks(4394), 2, null, "Terminar la API de producción" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84c192"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc12"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc10"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 6, 14, 23, 32, 889, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0ca5fc9a-a7c4-4505-b9e1-18767c84cc11"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 6, 14, 23, 32, 889, DateTimeKind.Local).AddTicks(5974));
        }
    }
}
