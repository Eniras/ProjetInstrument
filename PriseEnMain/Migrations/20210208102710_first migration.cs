using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emetteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAttributs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAttributs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TypeInstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_TypeInstruments_TypeInstrumentId",
                        column: x => x.TypeInstrumentId,
                        principalTable: "TypeInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentSous_jacents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentSous_jacents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeInstrumentTypeAttributs",
                columns: table => new
                {
                    TypeInstrumentId = table.Column<int>(type: "int", nullable: false),
                    TypeAttributId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInstrumentTypeAttributs", x => new { x.TypeInstrumentId, x.TypeAttributId });
                    table.ForeignKey(
                        name: "FK_TypeInstrumentTypeAttributs_TypeAttributs_TypeAttributId",
                        column: x => x.TypeAttributId,
                        principalTable: "TypeAttributs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeInstrumentTypeAttributs_TypeInstruments_TypeInstrumentId",
                        column: x => x.TypeInstrumentId,
                        principalTable: "TypeInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAttributId = table.Column<int>(type: "int", nullable: false),
                    ValueInstrumentId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: true),
                    ValueContratId = table.Column<int>(type: "int", nullable: true),
                    ValueEmetteurId = table.Column<int>(type: "int", nullable: true),
                    ValueOther = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributs_Contrats_ValueContratId",
                        column: x => x.ValueContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributs_Emetteurs_ValueEmetteurId",
                        column: x => x.ValueEmetteurId,
                        principalTable: "Emetteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributs_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributs_TypeAttributs_TypeAttributId",
                        column: x => x.TypeAttributId,
                        principalTable: "TypeAttributs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_InstrumentId",
                table: "Attributs",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_TypeAttributId",
                table: "Attributs",
                column: "TypeAttributId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_ValueContratId",
                table: "Attributs",
                column: "ValueContratId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_ValueEmetteurId",
                table: "Attributs",
                column: "ValueEmetteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_TypeInstrumentId",
                table: "Instruments",
                column: "TypeInstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentSous_jacents_TypeId",
                table: "InstrumentSous_jacents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeInstrumentTypeAttributs_TypeAttributId",
                table: "TypeInstrumentTypeAttributs",
                column: "TypeAttributId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributs");

            migrationBuilder.DropTable(
                name: "InstrumentSous_jacents");

            migrationBuilder.DropTable(
                name: "TypeInstrumentTypeAttributs");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Emetteurs");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "TypeAttributs");

            migrationBuilder.DropTable(
                name: "TypeInstruments");
        }
    }
}
