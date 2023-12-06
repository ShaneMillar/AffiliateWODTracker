using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class IdColumnUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WODs",
                newName: "WodId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Scores",
                newName: "ScoreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Affiliates",
                newName: "AffiliateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WodId",
                table: "WODs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ScoreId",
                table: "Scores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AffiliateId",
                table: "Affiliates",
                newName: "Id");
        }
    }
}
