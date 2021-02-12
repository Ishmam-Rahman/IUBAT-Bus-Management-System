using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class feedbackk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "FeedBack",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FeedBack",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "FeedBack");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "FeedBack",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}
