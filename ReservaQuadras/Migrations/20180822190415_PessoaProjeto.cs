using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReservaQuadras.Migrations
{
    public partial class PessoaProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaProjeto",
                columns: table => new
                {
                    PessoaProjetoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaID = table.Column<int>(nullable: false),
                    ProjetoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaProjeto", x => x.PessoaProjetoID);
                    table.ForeignKey(
                        name: "FK_PessoaProjeto_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaProjeto_Projeto_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaProjeto_PessoaID",
                table: "PessoaProjeto",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaProjeto_ProjetoID",
                table: "PessoaProjeto",
                column: "ProjetoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaProjeto");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
