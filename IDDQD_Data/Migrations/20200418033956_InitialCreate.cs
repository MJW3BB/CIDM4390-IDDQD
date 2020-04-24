using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDDQD_Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Discipline = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CartesianIndex = table.Column<int>(nullable: false),
                    SemioticIndex = table.Column<int>(nullable: false),
                    Etymology = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CartesianIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstituentCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberCompetencyId = table.Column<int>(nullable: true),
                    CompetencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituentCompetencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstituentCompetencies_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituentCompetencies_Competencies_MemberCompetencyId",
                        column: x => x.MemberCompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyDispositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DispositionId = table.Column<int>(nullable: true),
                    CompetencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyDispositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetencyDispositions_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetencyDispositions_Dispositions_DispositionId",
                        column: x => x.DispositionId,
                        principalTable: "Dispositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KSPairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KnowledgeElementId = table.Column<int>(nullable: true),
                    SkillLevelId = table.Column<int>(nullable: true),
                    AtomicCompetencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KSPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KSPairs_Competencies_AtomicCompetencyId",
                        column: x => x.AtomicCompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KSPairs_KnowledgeElements_KnowledgeElementId",
                        column: x => x.KnowledgeElementId,
                        principalTable: "KnowledgeElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KSPairs_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetencyDispositions_CompetencyId",
                table: "CompetencyDispositions",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencyDispositions_DispositionId",
                table: "CompetencyDispositions",
                column: "DispositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentCompetencies_CompetencyId",
                table: "ConstituentCompetencies",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentCompetencies_MemberCompetencyId",
                table: "ConstituentCompetencies",
                column: "MemberCompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_KSPairs_AtomicCompetencyId",
                table: "KSPairs",
                column: "AtomicCompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_KSPairs_KnowledgeElementId",
                table: "KSPairs",
                column: "KnowledgeElementId");

            migrationBuilder.CreateIndex(
                name: "IX_KSPairs_SkillLevelId",
                table: "KSPairs",
                column: "SkillLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetencyDispositions");

            migrationBuilder.DropTable(
                name: "ConstituentCompetencies");

            migrationBuilder.DropTable(
                name: "KSPairs");

            migrationBuilder.DropTable(
                name: "Dispositions");

            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "KnowledgeElements");

            migrationBuilder.DropTable(
                name: "SkillLevels");
        }
    }
}
