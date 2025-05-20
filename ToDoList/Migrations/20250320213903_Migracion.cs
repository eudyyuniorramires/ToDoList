using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tareas_usuarios_UsuarioId",
                table: "tareas");

            migrationBuilder.DropIndex(
                name: "IX_tareas_UsuarioId",
                table: "tareas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tareas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tareas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tareas_UsuarioId",
                table: "tareas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tareas_usuarios_UsuarioId",
                table: "tareas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");
        }
    }
}
