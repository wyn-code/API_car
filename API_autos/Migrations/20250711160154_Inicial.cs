﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_autos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condicion",
                columns: table => new
                {
                    Id_condicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    condicionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicion", x => x.Id_condicion);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeAuto",
                columns: table => new
                {
                    Id_Tipo_Auto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_autos = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeAuto", x => x.Id_Tipo_Auto);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id_Modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaId_Marca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id_Modelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId_Marca",
                        column: x => x.MarcaId_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Id_Marca");
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id_Autos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_condicion = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año_Modelo = table.Column<int>(type: "int", nullable: false),
                    Id_Tipo_Auto = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Id_Modelo = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id_Autos);
                    table.ForeignKey(
                        name: "FK_Autos_Condicion_Id_condicion",
                        column: x => x.Id_condicion,
                        principalTable: "Condicion",
                        principalColumn: "Id_condicion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_Modelos_Id_Modelo",
                        column: x => x.Id_Modelo,
                        principalTable: "Modelos",
                        principalColumn: "Id_Modelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_TiposDeAuto_Id_Tipo_Auto",
                        column: x => x.Id_Tipo_Auto,
                        principalTable: "TiposDeAuto",
                        principalColumn: "Id_Tipo_Auto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Condicion",
                columns: new[] { "Id_condicion", "condicionName" },
                values: new object[,]
                {
                    { 1, "0KM" },
                    { 2, "Usado" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Vendido" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id_Marca", "Nombre_Marca" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "Honda" },
                    { 4, "Chevrolet" },
                    { 5, "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id_Modelo", "MarcaId_Marca", "Nombre_Modelo" },
                values: new object[,]
                {
                    { 1, null, "Corolla" },
                    { 2, null, "Hilux" },
                    { 3, null, "F-150" },
                    { 4, null, "Civic" },
                    { 5, null, "Camaro" },
                    { 6, null, "Serie 3" }
                });

            migrationBuilder.InsertData(
                table: "TiposDeAuto",
                columns: new[] { "Id_Tipo_Auto", "tipo_autos" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "SUV" },
                    { 3, "Pickup" },
                    { 4, "Coupé" },
                    { 5, "Hatchback" },
                    { 6, "Convertible" }
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id_Autos", "Año_Modelo", "Descripcion", "Disponible", "EstadoId", "Id_Modelo", "Id_Tipo_Auto", "Id_condicion", "Marca", "Motor", "Precio", "fecha_creacion" },
                values: new object[,]
                {
                    { 1, 2019, "Toyota Corolla usado, excelente estado, único dueño.", true, 1, 1, 1, 1, "Toyota", "1.8L 4 cilindros", 35000.0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2020, "Toyota Hilux, pickup usada, ideal para trabajo.", true, 1, 2, 3, 2, "Toyota", "2.8L diesel", 40000.0, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2024, "Ford F-150 0KM, versión full equipo.", true, 1, 3, 3, 1, "Ford", "3.3L V6", 45000.0, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2018, "Honda Civic usado, cuidado y mantenido, vendido recientemente.", false, 2, 4, 1, 2, "Honda", "2.0L 4 cilindros", 22000.0, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2024, "BMW Serie 3 convertible, edición especial 0KM.", true, 1, 6, 6, 1, "BMW", "2.0L turbo", 52000.0, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_EstadoId",
                table: "Autos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Id_condicion",
                table: "Autos",
                column: "Id_condicion");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Id_Modelo",
                table: "Autos",
                column: "Id_Modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Id_Tipo_Auto",
                table: "Autos",
                column: "Id_Tipo_Auto");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId_Marca",
                table: "Modelos",
                column: "MarcaId_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeAuto_tipo_autos",
                table: "TiposDeAuto",
                column: "tipo_autos",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Condicion");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TiposDeAuto");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
