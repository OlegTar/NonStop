using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class univercitynamestring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Univercities",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Univercities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
