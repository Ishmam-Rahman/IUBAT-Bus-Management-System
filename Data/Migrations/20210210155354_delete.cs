using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "FeedBack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FeedBack",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
