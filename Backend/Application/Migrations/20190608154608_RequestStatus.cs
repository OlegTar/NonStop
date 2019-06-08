using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class RequestStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Requests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }
    }
}
