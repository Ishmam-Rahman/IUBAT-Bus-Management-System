using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusDetails",
                table: "BusDetails");

            migrationBuilder.RenameTable(
                name: "BusDetails",
                newName: "Bus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bus",
                table: "Bus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bus",
                table: "Bus");

            migrationBuilder.RenameTable(
                name: "Bus",
                newName: "BusDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusDetails",
                table: "BusDetails",
                column: "Id");
        }
    }
}
