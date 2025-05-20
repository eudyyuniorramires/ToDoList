using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_tareas_IdUsuario",
                table: "tareas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_tareas_usuarios_IdUsuario",
                table: "tareas",
                column: "IdUsuario",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tareas_usuarios_IdUsuario",
                table: "tareas");

            migrationBuilder.DropIndex(
                name: "IX_tareas_IdUsuario",
                table: "tareas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tareas_UsuarioId",
                table: "tareas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tareas_usuarios_UsuarioId",
                table: "tareas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
