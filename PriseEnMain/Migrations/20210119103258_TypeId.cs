using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class TypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "InstrumentSous_jacents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents",
                column: "TypeId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "InstrumentSous_jacents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentSous_jacents_TypeInstruments_TypeId",
                table: "InstrumentSous_jacents",
                column: "TypeId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
