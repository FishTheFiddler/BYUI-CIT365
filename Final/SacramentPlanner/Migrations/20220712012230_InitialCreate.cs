using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HymnTitle = table.Column<string>(nullable: true),
                    HymnType = table.Column<string>(nullable: true),
                    HymnNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnID);
                });

            migrationBuilder.CreateTable(
                name: "SacramentPlan",
                columns: table => new
                {
                    SacramentPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Conducting = table.Column<string>(nullable: true),
                    Invocation = table.Column<string>(nullable: true),
                    OpeningHymnHymnID = table.Column<int>(nullable: true),
                    SacramentHymnHymnID = table.Column<int>(nullable: true),
                    NumberOfSpeakers = table.Column<int>(nullable: false),
                    ClosingHymnHymnID = table.Column<int>(nullable: true),
                    Benediction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentPlan", x => x.SacramentPlanID);
                    table.ForeignKey(
                        name: "FK_SacramentPlan_Hymn_ClosingHymnHymnID",
                        column: x => x.ClosingHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentPlan_Hymn_OpeningHymnHymnID",
                        column: x => x.OpeningHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentPlan_Hymn_SacramentHymnHymnID",
                        column: x => x.SacramentHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SacramentPlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_SacramentPlan_SacramentPlanID",
                        column: x => x.SacramentPlanID,
                        principalTable: "SacramentPlan",
                        principalColumn: "SacramentPlanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SacramentPlan_ClosingHymnHymnID",
                table: "SacramentPlan",
                column: "ClosingHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentPlan_OpeningHymnHymnID",
                table: "SacramentPlan",
                column: "OpeningHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentPlan_SacramentHymnHymnID",
                table: "SacramentPlan",
                column: "SacramentHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacramentPlanID",
                table: "Speaker",
                column: "SacramentPlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SacramentPlan");

            migrationBuilder.DropTable(
                name: "Hymn");
        }
    }
}
