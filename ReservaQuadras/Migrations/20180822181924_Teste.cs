using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReservaQuadras.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleticas",
                columns: table => new
                {
                    AtleticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleticas", x => x.AtleticaID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaAtleticas",
                columns: table => new
                {
                    PessoaAtleticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtleticaID = table.Column<int>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaAtleticas", x => x.PessoaAtleticaID);
                    table.ForeignKey(
                        name: "FK_PessoaAtleticas_Atleticas_AtleticaID",
                        column: x => x.AtleticaID,
                        principalTable: "Atleticas",
                        principalColumn: "AtleticaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaAtleticas_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaAtleticas_AtleticaID",
                table: "PessoaAtleticas",
                column: "AtleticaID");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaAtleticas_PessoaID",
                table: "PessoaAtleticas",
                column: "PessoaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaAtleticas");

            migrationBuilder.DropTable(
                name: "Atleticas");
        }
    }
}
