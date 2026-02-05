using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShotUrl.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityUrls",
                columns: table => new
                {
                    ShortId = table.Column<string>(type: "text", nullable: false),
                    OriginalUrl = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityUrls", x => x.ShortId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityUrls_ShortId",
                table: "EntityUrls",
                column: "ShortId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityUrls");
        }
    }
}
