using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IUBAT_Bus_Management_System.Data.Migrations
{
    public partial class delete1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                table: "FeedBack",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time",
                table: "FeedBack");
        }
    }
}
