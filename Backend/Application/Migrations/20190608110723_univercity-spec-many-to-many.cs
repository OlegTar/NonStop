using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class univercityspecmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnivercitySpecialization",
                columns: table => new
                {
                    UnivercityId = table.Column<int>(nullable: false),
                    SpecializationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnivercitySpecialization", x => new { x.UnivercityId, x.SpecializationId });
                    table.ForeignKey(
                        name: "FK_UnivercitySpecialization_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnivercitySpecialization_Univercities_UnivercityId",
                        column: x => x.UnivercityId,
                        principalTable: "Univercities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnivercitySpecialization_SpecializationId",
                table: "UnivercitySpecialization",
                column: "SpecializationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnivercitySpecialization");
        }
    }
}
