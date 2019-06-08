using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class univercityspec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnivercitySpecialization_Specializations_SpecializationId",
                table: "UnivercitySpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_UnivercitySpecialization_Univercities_UnivercityId",
                table: "UnivercitySpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnivercitySpecialization",
                table: "UnivercitySpecialization");

            migrationBuilder.RenameTable(
                name: "UnivercitySpecialization",
                newName: "UnivercitySpecializations");

            migrationBuilder.RenameIndex(
                name: "IX_UnivercitySpecialization_SpecializationId",
                table: "UnivercitySpecializations",
                newName: "IX_UnivercitySpecializations_SpecializationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnivercitySpecializations",
                table: "UnivercitySpecializations",
                columns: new[] { "UnivercityId", "SpecializationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UnivercitySpecializations_Specializations_SpecializationId",
                table: "UnivercitySpecializations",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnivercitySpecializations_Univercities_UnivercityId",
                table: "UnivercitySpecializations",
                column: "UnivercityId",
                principalTable: "Univercities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnivercitySpecializations_Specializations_SpecializationId",
                table: "UnivercitySpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_UnivercitySpecializations_Univercities_UnivercityId",
                table: "UnivercitySpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnivercitySpecializations",
                table: "UnivercitySpecializations");

            migrationBuilder.RenameTable(
                name: "UnivercitySpecializations",
                newName: "UnivercitySpecialization");

            migrationBuilder.RenameIndex(
                name: "IX_UnivercitySpecializations_SpecializationId",
                table: "UnivercitySpecialization",
                newName: "IX_UnivercitySpecialization_SpecializationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnivercitySpecialization",
                table: "UnivercitySpecialization",
                columns: new[] { "UnivercityId", "SpecializationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UnivercitySpecialization_Specializations_SpecializationId",
                table: "UnivercitySpecialization",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnivercitySpecialization_Univercities_UnivercityId",
                table: "UnivercitySpecialization",
                column: "UnivercityId",
                principalTable: "Univercities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
