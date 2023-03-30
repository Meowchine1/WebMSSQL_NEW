using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMSSQL.Migrations
{
    /// <inheritdoc />
    public partial class categoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "resourses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "resourses",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "resourses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "resourses",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryId",
                value: 0);
        }
    }
}
