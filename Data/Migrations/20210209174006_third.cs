using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Busid",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "BusName",
                table: "Route",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusName",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "Busid",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
