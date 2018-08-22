using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservaQuadras.Migrations
{
    public partial class Horario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspacoFisico",
                columns: table => new
                {
                    EspacoFisicoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    IsLiberado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspacoFisico", x => x.EspacoFisicoID);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaID = table.Column<int>(nullable: false),
                    EspacoFisicoID = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFim = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioID);
                    table.ForeignKey(
                        name: "FK_Horario_DiaDaSemana_DiaID",
                        column: x => x.DiaID,
                        principalTable: "DiaDaSemana",
                        principalColumn: "DiaDaSemanaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horario_EspacoFisico_EspacoFisicoID",
                        column: x => x.EspacoFisicoID,
                        principalTable: "EspacoFisico",
                        principalColumn: "EspacoFisicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horario_DiaID",
                table: "Horario",
                column: "DiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_EspacoFisicoID",
                table: "Horario",
                column: "EspacoFisicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "EspacoFisico");
        }
    }
}
