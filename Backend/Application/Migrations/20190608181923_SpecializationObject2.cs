using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class SpecializationObject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecializationSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnivercityId = table.Column<int>(nullable: true),
                    SpecializationId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecializationSubjects_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecializationSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecializationSubjects_Univercities_UnivercityId",
                        column: x => x.UnivercityId,
                        principalTable: "Univercities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSubjects_SpecializationId",
                table: "SpecializationSubjects",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSubjects_SubjectId",
                table: "SpecializationSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSubjects_UnivercityId",
                table: "SpecializationSubjects",
                column: "UnivercityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationSubjects");
        }
    }
}
