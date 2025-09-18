using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AxaColpatria.NotAxApp.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsUsuarioTableroNota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
