using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOwnerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Affiliates_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AffiliateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Affiliates_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId");
        }
    }
}
