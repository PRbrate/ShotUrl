using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShotUrl.Migrations
{
    /// <inheritdoc />
    public partial class autoIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityUrls",
                table: "EntityUrls");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "EntityUrls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityUrls",
                table: "EntityUrls",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntityUrls_ShortId",
                table: "EntityUrls",
                column: "ShortId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityUrls",
                table: "EntityUrls");

            migrationBuilder.DropIndex(
                name: "IX_EntityUrls_ShortId",
                table: "EntityUrls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EntityUrls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityUrls",
                table: "EntityUrls",
                column: "ShortId");
        }
    }
}
