using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emetteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emetteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentSous_jacents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentSous_jacents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInstruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeInstrumentId = table.Column<int>(type: "int", nullable: true),
                    emetteurId = table.Column<int>(type: "int", nullable: true),
                    contratId = table.Column<int>(type: "int", nullable: true),
                    attributId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_Attributs_attributId",
                        column: x => x.attributId,
                        principalTable: "Attributs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instruments_Contrats_contratId",
                        column: x => x.contratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instruments_Emetteurs_emetteurId",
                        column: x => x.emetteurId,
                        principalTable: "Emetteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instruments_TypeInstruments_typeInstrumentId",
                        column: x => x.typeInstrumentId,
                        principalTable: "TypeInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_attributId",
                table: "Instruments",
                column: "attributId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_contratId",
                table: "Instruments",
                column: "contratId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_emetteurId",
                table: "Instruments",
                column: "emetteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_typeInstrumentId",
                table: "Instruments",
                column: "typeInstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "InstrumentSous_jacents");

            migrationBuilder.DropTable(
                name: "Attributs");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Emetteurs");

            migrationBuilder.DropTable(
                name: "TypeInstruments");
        }
    }
}
