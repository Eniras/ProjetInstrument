using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class Instrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Attributs_attributId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Contrats_contratId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Emetteurs_emetteurId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_InstrumentSous_jacents_instrumentSous_JacentId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_TypeInstruments_typeInstrumentId",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_attributId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "attributId",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "typeInstrumentId",
                table: "Instruments",
                newName: "TypeInstrumentId");

            migrationBuilder.RenameColumn(
                name: "emetteurId",
                table: "Instruments",
                newName: "EmetteurId");

            migrationBuilder.RenameColumn(
                name: "contratId",
                table: "Instruments",
                newName: "ContratId");

            migrationBuilder.RenameColumn(
                name: "instrumentSous_JacentId",
                table: "Instruments",
                newName: "InstrumentSousJacentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_typeInstrumentId",
                table: "Instruments",
                newName: "IX_Instruments_TypeInstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_emetteurId",
                table: "Instruments",
                newName: "IX_Instruments_EmetteurId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_contratId",
                table: "Instruments",
                newName: "IX_Instruments_ContratId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_instrumentSous_JacentId",
                table: "Instruments",
                newName: "IX_Instruments_InstrumentSousJacentId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeInstrumentId",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentId",
                table: "Attributs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributs_InstrumentId",
                table: "Attributs",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributs_Instruments_InstrumentId",
                table: "Attributs",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Contrats_ContratId",
                table: "Instruments",
                column: "ContratId",
                principalTable: "Contrats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Emetteurs_EmetteurId",
                table: "Instruments",
                column: "EmetteurId",
                principalTable: "Emetteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Instruments_InstrumentSousJacentId",
                table: "Instruments",
                column: "InstrumentSousJacentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_TypeInstruments_TypeInstrumentId",
                table: "Instruments",
                column: "TypeInstrumentId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributs_Instruments_InstrumentId",
                table: "Attributs");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Contrats_ContratId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Emetteurs_EmetteurId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Instruments_InstrumentSousJacentId",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_TypeInstruments_TypeInstrumentId",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Attributs_InstrumentId",
                table: "Attributs");

            migrationBuilder.DropColumn(
                name: "InstrumentId",
                table: "Attributs");

            migrationBuilder.RenameColumn(
                name: "TypeInstrumentId",
                table: "Instruments",
                newName: "typeInstrumentId");

            migrationBuilder.RenameColumn(
                name: "EmetteurId",
                table: "Instruments",
                newName: "emetteurId");

            migrationBuilder.RenameColumn(
                name: "ContratId",
                table: "Instruments",
                newName: "contratId");

            migrationBuilder.RenameColumn(
                name: "InstrumentSousJacentId",
                table: "Instruments",
                newName: "instrumentSous_JacentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_TypeInstrumentId",
                table: "Instruments",
                newName: "IX_Instruments_typeInstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_EmetteurId",
                table: "Instruments",
                newName: "IX_Instruments_emetteurId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_ContratId",
                table: "Instruments",
                newName: "IX_Instruments_contratId");

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_InstrumentSousJacentId",
                table: "Instruments",
                newName: "IX_Instruments_instrumentSous_JacentId");

            migrationBuilder.AlterColumn<int>(
                name: "typeInstrumentId",
                table: "Instruments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "attributId",
                table: "Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_attributId",
                table: "Instruments",
                column: "attributId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Attributs_attributId",
                table: "Instruments",
                column: "attributId",
                principalTable: "Attributs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Contrats_contratId",
                table: "Instruments",
                column: "contratId",
                principalTable: "Contrats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Emetteurs_emetteurId",
                table: "Instruments",
                column: "emetteurId",
                principalTable: "Emetteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_InstrumentSous_jacents_instrumentSous_JacentId",
                table: "Instruments",
                column: "instrumentSous_JacentId",
                principalTable: "InstrumentSous_jacents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_TypeInstruments_typeInstrumentId",
                table: "Instruments",
                column: "typeInstrumentId",
                principalTable: "TypeInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
