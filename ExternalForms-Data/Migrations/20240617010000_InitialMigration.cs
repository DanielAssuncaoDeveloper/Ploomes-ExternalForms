using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExternalForms_Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "archives",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archives", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "field_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, defaultValue: ""),
                    data_type = table.Column<int>(type: "int", nullable: false),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "form_models",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    image_archive_id = table.Column<int>(type: "int", nullable: true),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_form_models_archives_image_archive_id",
                        column: x => x.image_archive_id,
                        principalTable: "archives",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_model_id = table.Column<int>(type: "int", nullable: false),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_answers_form_models_form_model_id",
                        column: x => x.form_model_id,
                        principalTable: "form_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "custom_fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    is_required = table.Column<bool>(type: "bit", nullable: false),
                    form_model_id = table.Column<int>(type: "int", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_fields", x => x.id);
                    table.ForeignKey(
                        name: "FK_custom_fields_field_types_field_type_id",
                        column: x => x.field_type_id,
                        principalTable: "field_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_custom_fields_form_models_form_model_id",
                        column: x => x.form_model_id,
                        principalTable: "form_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "answer_fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer_id = table.Column<int>(type: "int", nullable: false),
                    custom_field_id = table.Column<int>(type: "int", nullable: false),
                    data_type = table.Column<int>(type: "int", nullable: false),
                    text_answer = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    numeric_answer = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    datetime_answer = table.Column<DateTime>(type: "datetime", nullable: false),
                    answer_archive_id = table.Column<int>(type: "int", nullable: true),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer_fields", x => x.id);
                    table.ForeignKey(
                        name: "FK_answer_fields_answers_answer_id",
                        column: x => x.answer_id,
                        principalTable: "answers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_answer_fields_archives_answer_archive_id",
                        column: x => x.answer_archive_id,
                        principalTable: "archives",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_answer_fields_custom_fields_custom_field_id",
                        column: x => x.custom_field_id,
                        principalTable: "custom_fields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "field_types",
                columns: new[] { "id", "created_at", "data_type", "is_inactive", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Texto simples", null },
                    { 2, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Parágrafo", null },
                    { 3, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Número simples", null },
                    { 4, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Moeda", null },
                    { 5, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Percentual", null },
                    { 6, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Data e hora", null },
                    { 7, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Data", null },
                    { 8, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Hora", null },
                    { 9, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Sim ou Não", null },
                    { 10, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Multiplas seleções", null },
                    { 11, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, "Multipla escolha", null },
                    { 12, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Arquivo", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answer_fields_answer_archive_id",
                table: "answer_fields",
                column: "answer_archive_id");

            migrationBuilder.CreateIndex(
                name: "IX_answer_fields_answer_id",
                table: "answer_fields",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_answer_fields_custom_field_id",
                table: "answer_fields",
                column: "custom_field_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_form_model_id",
                table: "answers",
                column: "form_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_fields_field_type_id",
                table: "custom_fields",
                column: "field_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_custom_fields_form_model_id",
                table: "custom_fields",
                column: "form_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_form_models_image_archive_id",
                table: "form_models",
                column: "image_archive_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer_fields");

            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "custom_fields");

            migrationBuilder.DropTable(
                name: "field_types");

            migrationBuilder.DropTable(
                name: "form_models");

            migrationBuilder.DropTable(
                name: "archives");
        }
    }
}
