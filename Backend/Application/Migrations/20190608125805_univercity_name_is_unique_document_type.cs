using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class univercity_name_is_unique_document_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Univercities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Univercities_Name",
                table: "Univercities",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentType_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Univercities_Name",
                table: "Univercities");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Univercities",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
