using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ioasys.IMDb.Data.Migrations
{
    public partial class script_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    NivelAcesso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Diretor = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    NivelAcesso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nota = table.Column<int>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "Ativo", "Login", "NivelAcesso", "Nome", "Senha" },
                values: new object[] { new Guid("2e1c2016-3039-466c-b3a8-d09a50aad01d"), true, "admin", 1, "Administrador de teste", "123456" });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Diretor", "Genero", "Nome" },
                values: new object[,]
                {
                    { new Guid("52c718c9-a600-4957-8f60-c06475084df6"), "Michel Hazanavicius", "Romance/Drama", "O Artista" },
                    { new Guid("e601cb2b-182c-45ba-b4eb-3f30424d852b"), "Michel Hazanavicius", "Guerra/Drama", "Apocalypse Now" },
                    { new Guid("93d1fd81-586b-4d37-a70d-a18528f47267"), "Stephen Frears", "Drama/Filme histórico", "A Rainha" },
                    { new Guid("6718fae1-c21b-46c5-b7d4-d0f9049f8032"), "Danny Boyle", "Drama/Sobrevivência", "127 Horas" },
                    { new Guid("62c2366d-9601-40ec-9a9d-cc7ae7eaf6c6"), "Ethan Coen, Joel Coen", "Comédia/Drama", "Um Homem Sério" },
                    { new Guid("6628a83c-64c6-41a6-9180-e1fd7c250ad1"), "Barry Levinson", "Drama/Melodrama", "Rain Man" },
                    { new Guid("75cb8257-3992-4835-a0c9-a63cb711dad5"), "Ingmar Bergman", "Drama/Obra de Época", "Gritos e Sussurros" },
                    { new Guid("38fc695b-16c8-45fd-b753-455acc1f9fd1"), "Michel Hazanavicius", "Romance/Drama", "O Piano" },
                    { new Guid("968182ed-1f8b-4fd2-b985-532dc3bbcbe4"), "Joe Wright", " Guerra/Drama", "O Destino de Uma Nação" },
                    { new Guid("d73b7efd-42f9-4979-ae2e-7e93158efb4a"), "Francis Ford Coppola", "Thriller/Mistério", "A Conversação" },
                    { new Guid("2f15c877-d674-49d1-aa0e-4fdbb51f7418"), "Ang Lee", "Crime/Drama", "Los Angeles - Cidade Proibida" },
                    { new Guid("7dc9f072-bdb5-462d-9a85-4e8a5566412a"), "Michel Hazanavicius", "Romance/Drama", "O Segredo de Brokeback Mountain" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Login", "NivelAcesso", "Nome", "Senha" },
                values: new object[] { new Guid("1abd2d05-070f-4e17-927d-a7f21a5a5b04"), true, "user", 2, "Usuário de teste", "123456" });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_FilmeId",
                table: "Votos",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_UsuarioId",
                table: "Votos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Votos");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
