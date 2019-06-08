using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class specialization_code_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Specializations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Specializations_Code",
                table: "Specializations",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Specializations_Code",
                table: "Specializations");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Specializations",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
