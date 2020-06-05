using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Confitec.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolaridade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 80, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 80, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EscolaridadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Escolaridade_EscolaridadeId",
                        column: x => x.EscolaridadeId,
                        principalTable: "Escolaridade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escolaridade",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Infantil" },
                    { 2, "Fundamental" },
                    { 3, "Médio" },
                    { 4, "Superior" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataNascimento", "Email", "EscolaridadeId", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 4, 20, 51, 12, 789, DateTimeKind.Local), "usuario1@teste.com.br", 1, "Usuario 1", "De Souza" },
                    { 2, new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), "usuario2@teste.com.br", 2, "Usuario 2", "De Souza" },
                    { 3, new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), "usuario3@teste.com.br", 3, "Usuario 3", "De Souza" },
                    { 4, new DateTime(2020, 6, 4, 20, 51, 12, 790, DateTimeKind.Local), "usuario4@teste.com.br", 4, "Usuario 4", "De Souza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EscolaridadeId",
                table: "Usuario",
                column: "EscolaridadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Escolaridade");
        }
    }
}
