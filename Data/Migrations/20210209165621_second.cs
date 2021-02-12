using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusName",
                table: "BusDetails",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusName",
                table: "BusDetails");
        }
    }
}
