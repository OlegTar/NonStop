using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class person_idinOauthProvider_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdInOAuthProvider",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdInOAuthProvider",
                table: "Persons",
                column: "IdInOAuthProvider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_IdInOAuthProvider",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "IdInOAuthProvider",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
