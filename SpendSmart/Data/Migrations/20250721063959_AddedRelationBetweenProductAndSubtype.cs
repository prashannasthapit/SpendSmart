using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendSmart.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationBetweenProductAndSubtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubTypeId",
                table: "Products",
                column: "SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubTypes_SubTypeId",
                table: "Products",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubTypes_SubTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "Products");
        }
    }
}
