using Microsoft.EntityFrameworkCore.Migrations;

namespace PriseEnMain.Migrations
{
    public partial class ThrirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "InstrumentSous_jacents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "InstrumentSous_jacents");
        }
    }
}
