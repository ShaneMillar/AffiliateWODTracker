using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffiliateWODTracker.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_StatusId",
                table: "Members",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Status_StatusId",
                table: "Members",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            // Seed data for the Status table
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Accepted" },
                    { 2, "Rejected" },
                    { 3, "Pending" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Status_StatusId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Members_StatusId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Members");
        }
    }
}
