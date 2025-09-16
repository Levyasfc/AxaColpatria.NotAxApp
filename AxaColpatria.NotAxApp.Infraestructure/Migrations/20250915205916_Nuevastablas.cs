using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AxaColpatria.NotAxApp.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Nuevastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableroId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tableros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tableros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tableros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TableroId",
                table: "Notas",
                column: "TableroId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tableros_UsuarioId",
                table: "Tableros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Tableros_TableroId",
                table: "Notas",
                column: "TableroId",
                principalTable: "Tableros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Tableros_TableroId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas");

            migrationBuilder.DropTable(
                name: "Tableros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Notas_TableroId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "TableroId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notas");
        }
    }
}
