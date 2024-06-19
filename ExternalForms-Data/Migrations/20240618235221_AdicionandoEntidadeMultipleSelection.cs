using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalForms_Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoEntidadeMultipleSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime_answer",
                table: "answer_fields",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "answer_multiple_selection_id",
                table: "answer_fields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "multiple_selections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    custom_field_id = table.Column<int>(type: "int", nullable: false),
                    is_inactive = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiple_selections", x => x.id);
                    table.ForeignKey(
                        name: "FK_multiple_selections_custom_fields_custom_field_id",
                        column: x => x.custom_field_id,
                        principalTable: "custom_fields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_answer_fields_answer_multiple_selection_id",
                table: "answer_fields",
                column: "answer_multiple_selection_id");

            migrationBuilder.CreateIndex(
                name: "IX_multiple_selections_custom_field_id",
                table: "multiple_selections",
                column: "custom_field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_fields_multiple_selections_answer_multiple_selection_id",
                table: "answer_fields",
                column: "answer_multiple_selection_id",
                principalTable: "multiple_selections",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_fields_multiple_selections_answer_multiple_selection_id",
                table: "answer_fields");

            migrationBuilder.DropTable(
                name: "multiple_selections");

            migrationBuilder.DropIndex(
                name: "IX_answer_fields_answer_multiple_selection_id",
                table: "answer_fields");

            migrationBuilder.DropColumn(
                name: "answer_multiple_selection_id",
                table: "answer_fields");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime_answer",
                table: "answer_fields",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 10,
                column: "data_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "field_types",
                keyColumn: "id",
                keyValue: 11,
                column: "data_type",
                value: 0);
        }
    }
}
