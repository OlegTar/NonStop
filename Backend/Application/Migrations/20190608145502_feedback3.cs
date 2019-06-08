using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class feedback3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Univercities_UnivercityId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UnivercityId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "UnivercityId",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnivercityId",
                table: "Feedbacks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UnivercityId",
                table: "Feedbacks",
                column: "UnivercityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Univercities_UnivercityId",
                table: "Feedbacks",
                column: "UnivercityId",
                principalTable: "Univercities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
