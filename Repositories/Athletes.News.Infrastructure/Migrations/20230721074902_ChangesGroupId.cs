using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athletes.News.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangesGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Groups_GroupId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_GroupId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Teams",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GroupId",
                table: "Teams",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Groups_GroupId",
                table: "Teams",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Groups_GroupId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_GroupId",
                table: "Teams");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "Teams",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GroupId1",
                table: "Teams",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Groups_GroupId1",
                table: "Teams",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
