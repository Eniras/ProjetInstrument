using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class cinq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "instrumentSous_JacentId",
                table: "Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_instrumentSous_JacentId",
                table: "Instruments",
                column: "instrumentSous_JacentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_InstrumentSous_jacents_instrumentSous_JacentId",
                table: "Instruments",
                column: "instrumentSous_JacentId",
                principalTable: "InstrumentSous_jacents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_InstrumentSous_jacents_instrumentSous_JacentId",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_instrumentSous_JacentId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "instrumentSous_JacentId",
                table: "Instruments");
        }
    }
}
