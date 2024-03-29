using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Migrations
{
    /// <inheritdoc />
    public partial class _0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tarefas",
                table: "tarefas");

            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "tarefas");

            migrationBuilder.RenameTable(
                name: "tarefas",
                newName: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Tarefas",
                newName: "Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "tarefas");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "tarefas",
                newName: "DataInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_tarefas",
                table: "tarefas",
                column: "Id");
        }
    }
}
