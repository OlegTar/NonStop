using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class person_id_inOauthProvider_avatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdInOAuthProvider",
                table: "Persons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdInOAuthProvider",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
