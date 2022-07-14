using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentPlanner.Migrations
{
    public partial class Speakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_SacramentPlan_SacramentPlanID",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "SacramentPlanID",
                table: "Speaker",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Speaker",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_SacramentPlan_SacramentPlanID",
                table: "Speaker",
                column: "SacramentPlanID",
                principalTable: "SacramentPlan",
                principalColumn: "SacramentPlanID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_SacramentPlan_SacramentPlanID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "SacramentPlanID",
                table: "Speaker",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_SacramentPlan_SacramentPlanID",
                table: "Speaker",
                column: "SacramentPlanID",
                principalTable: "SacramentPlan",
                principalColumn: "SacramentPlanID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
