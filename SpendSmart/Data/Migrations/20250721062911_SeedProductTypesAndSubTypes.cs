using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpendSmart.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTypesAndSubTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubTypes",
                columns: new[] { "Id", "ProductTypeId", "SubTypeName" },
                values: new object[,]
                {
                    { 1, 1, "T-Shirt" },
                    { 2, 1, "Jeans" },
                    { 3, 2, "iPhone" },
                    { 4, 2, "Android" },
                    { 5, 3, "Gaming Laptop" },
                    { 6, 3, "Ultrabook" },
                    { 7, 4, "Notebook" },
                    { 8, 4, "Pen" },
                    { 9, 5, "Wireless" },
                    { 10, 5, "Wired" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubTypes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
