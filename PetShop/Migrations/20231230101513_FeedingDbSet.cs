using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class FeedingDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedule_Cage_CageId",
                table: "FeedingSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedingSchedule",
                table: "FeedingSchedule");

            migrationBuilder.RenameTable(
                name: "FeedingSchedule",
                newName: "feedingSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_FeedingSchedule_CageId",
                table: "feedingSchedules",
                newName: "IX_feedingSchedules_CageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedingSchedules",
                table: "feedingSchedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_feedingSchedules_Cage_CageId",
                table: "feedingSchedules",
                column: "CageId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedingSchedules_Cage_CageId",
                table: "feedingSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feedingSchedules",
                table: "feedingSchedules");

            migrationBuilder.RenameTable(
                name: "feedingSchedules",
                newName: "FeedingSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_feedingSchedules_CageId",
                table: "FeedingSchedule",
                newName: "IX_FeedingSchedule_CageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedingSchedule",
                table: "FeedingSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedule_Cage_CageId",
                table: "FeedingSchedule",
                column: "CageId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
