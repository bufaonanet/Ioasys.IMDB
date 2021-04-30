using Microsoft.EntityFrameworkCore.Migrations;

namespace Ioasys.IMDb.Data.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direto",
                table: "Filmes",
                newName: "Diretor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diretor",
                table: "Filmes",
                newName: "Direto");
        }
    }
}
