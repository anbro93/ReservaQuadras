using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservaQuadras.Migrations
{
    public partial class DiaDaSemana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDaSemana",
                columns: table => new
                {
                    DiaDaSemanaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDaSemana", x => x.DiaDaSemanaID);
                });

            migrationBuilder.InsertData(
                table: "DiaDaSemana",
                columns: new[] { "DiaDaSemanaID", "Dia" },
                values: new object[,]
                {
                    { 1, "Segunda-Feira" },
                    { 2, "Terça-Feira" },
                    { 3, "Quarta-Feira" },
                    { 4, "Quinta-Feira" },
                    { 5, "Sexta-Feira" },
                    { 6, "Sábado" },
                    { 7, "Domingo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaDaSemana");
        }
    }
}
