using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddingCreatedDateToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "WODs",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Scores",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Comments",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Affiliates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Affiliates");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "WODs",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Scores",
                newName: "DatePosted");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Comments",
                newName: "DatePosted");
        }
    }
}
