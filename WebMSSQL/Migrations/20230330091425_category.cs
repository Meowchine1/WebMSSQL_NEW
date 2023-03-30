using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMSSQL.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_categories_new",
                table: "categories_new");

            migrationBuilder.RenameTable(
                name: "categories_new",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "categories_new");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories_new",
                table: "categories_new",
                column: "Id");
        }
    }
}
