using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeAttribut",
                table: "Attributs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeInstrumentId",
                table: "Attributs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_TypeInstrumentId",
                table: "Attributs",
                column: "TypeInstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributs_TypeInstruments_TypeInstrumentId",
                table: "Attributs",
                column: "TypeInstrumentId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributs_TypeInstruments_TypeInstrumentId",
                table: "Attributs");

            migrationBuilder.DropIndex(
                name: "IX_Attributs_TypeInstrumentId",
                table: "Attributs");

            migrationBuilder.DropColumn(
                name: "TypeAttribut",
                table: "Attributs");

            migrationBuilder.DropColumn(
                name: "TypeInstrumentId",
                table: "Attributs");
        }
    }
}
