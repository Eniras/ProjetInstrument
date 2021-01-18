using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class quatre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "InstrumentSous_jacents");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "InstrumentSous_jacents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentSous_jacents_TypeId",
                table: "InstrumentSous_jacents",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents",
                column: "TypeId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentSous_jacents_TypeId",
                table: "InstrumentSous_jacents");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "InstrumentSous_jacents");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "InstrumentSous_jacents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
