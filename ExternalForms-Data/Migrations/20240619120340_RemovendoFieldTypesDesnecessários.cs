using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExternalForms_Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoFieldTypesDesnecessários : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "field_types",
                columns: new[] { "id", "created_at", "data_type", "is_inactive", "name", "updated_at" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Parágrafo", null },
                    { 4, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Moeda", null },
                    { 5, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Percentual", null },
                    { 9, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Sim ou Não", null }
                });
        }
    }
}
