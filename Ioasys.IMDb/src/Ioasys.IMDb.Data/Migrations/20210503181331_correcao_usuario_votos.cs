using Microsoft.EntityFrameworkCore.Migrations;

namespace Ioasys.IMDb.Data.Migrations
{
    public partial class correcao_usuario_votos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votos_UsuarioId",
                table: "Votos");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_UsuarioId",
                table: "Votos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votos_UsuarioId",
                table: "Votos");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_UsuarioId",
                table: "Votos",
                column: "UsuarioId",
                unique: true);
        }
    }
}
