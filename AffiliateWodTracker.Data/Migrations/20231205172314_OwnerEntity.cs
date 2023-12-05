using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class OwnerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs");

            migrationBuilder.AddColumn<int>(
                name: "AffiliateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Affiliates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalTable: "Affiliates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliates_OwnerId",
                table: "Affiliates",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AffiliateId",
                table: "Members",
                column: "AffiliateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_AspNetUsers_OwnerId",
                table: "Affiliates",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Affiliates_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_AspNetUsers_OwnerId",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Affiliates_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Affiliates_OwnerId",
                table: "Affiliates");

            migrationBuilder.DropColumn(
                name: "AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Affiliates");

            migrationBuilder.AddForeignKey(
                name: "FK_WODs_Affiliates_AffiliateId",
                table: "WODs",
                column: "AffiliateId",
                principalTable: "Affiliates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
