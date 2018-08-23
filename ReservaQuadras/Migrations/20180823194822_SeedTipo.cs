using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservaQuadras.Migrations
{
    public partial class SeedTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservaID",
                table: "Horario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoReserva",
                columns: table => new
                {
                    TipoReservaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    MaxHoras = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReserva", x => x.TipoReservaID);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    TipoID = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    PessoaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reserva_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_TipoReserva_TipoID",
                        column: x => x.TipoID,
                        principalTable: "TipoReserva",
                        principalColumn: "TipoReservaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoReserva",
                columns: new[] { "TipoReservaID", "MaxHoras", "Nome" },
                values: new object[] { 1, 2f, "Comunidade" });

            migrationBuilder.InsertData(
                table: "TipoReserva",
                columns: new[] { "TipoReservaID", "MaxHoras", "Nome" },
                values: new object[] { 2, 10f, "Atlética" });

            migrationBuilder.InsertData(
                table: "TipoReserva",
                columns: new[] { "TipoReservaID", "MaxHoras", "Nome" },
                values: new object[] { 3, null, "Projeto" });

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ReservaID",
                table: "Horario",
                column: "ReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PessoaID",
                table: "Reserva",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_TipoID",
                table: "Reserva",
                column: "TipoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Reserva_ReservaID",
                table: "Horario",
                column: "ReservaID",
                principalTable: "Reserva",
                principalColumn: "ReservaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Reserva_ReservaID",
                table: "Horario");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TipoReserva");

            migrationBuilder.DropIndex(
                name: "IX_Horario_ReservaID",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "ReservaID",
                table: "Horario");
        }
    }
}
