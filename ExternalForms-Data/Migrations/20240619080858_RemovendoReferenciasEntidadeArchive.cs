using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExternalForms_Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoReferenciasEntidadeArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_fields_archives_answer_archive_id",
                table: "answer_fields");

            migrationBuilder.DropForeignKey(
                name: "FK_form_models_archives_image_archive_id",
                table: "form_models");

            migrationBuilder.DropTable(
                name: "archives");

            migrationBuilder.DropIndex(
                name: "IX_form_models_image_archive_id",
                table: "form_models");

            migrationBuilder.DropIndex(
                name: "IX_answer_fields_answer_archive_id",
                table: "answer_fields");

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "image_archive_id",
                table: "form_models");

            migrationBuilder.DropColumn(
                name: "answer_archive_id",
                table: "answer_fields");

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 10,
                column: "data_type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 11,
                column: "data_type",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "image_archive_id",
                table: "form_models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "answer_archive_id",
                table: "answer_fields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "archives",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archives", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 10,
                column: "data_type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 11,
                column: "data_type",
                value: 4);

            migrationBuilder.InsertData(
                table: "field_types",
                columns: new[] { "id", "created_at", "data_type", "is_inactive", "name", "updated_at" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Data", null },
                    { 8, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Hora", null },
                    { 12, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Arquivo", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_form_models_image_archive_id",
                table: "form_models",
                column: "image_archive_id");

            migrationBuilder.CreateIndex(
                name: "IX_answer_fields_answer_archive_id",
                table: "answer_fields",
                column: "answer_archive_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_fields_archives_answer_archive_id",
                table: "answer_fields",
                column: "answer_archive_id",
                principalTable: "archives",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_form_models_archives_image_archive_id",
                table: "form_models",
                column: "image_archive_id",
                principalTable: "archives",
                principalColumn: "id");
        }
    }
}
