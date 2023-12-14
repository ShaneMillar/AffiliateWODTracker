using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class WodUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WODs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WODs_UserId",
                table: "WODs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WODs_AspNetUsers_UserId",
                table: "WODs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs");

            migrationBuilder.DropForeignKey(
                name: "FK_WODs_AspNetUsers_UserId",
                table: "WODs");

            migrationBuilder.DropIndex(
                name: "IX_WODs_UserId",
                table: "WODs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WODs");

            migrationBuilder.AddForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
