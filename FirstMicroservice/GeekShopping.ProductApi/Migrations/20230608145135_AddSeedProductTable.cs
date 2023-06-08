using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PRODUCT",
                columns: new[] { "id", "CATEGORY_NAME", "DESCRIPTION", "IMAGE_URL", "NAME", "PRICE" },
                values: new object[,]
                {
                    { 5L, "Category", "Description", "Teste", "Name", 99.9m },
                    { 6L, "Category", "Description", "Teste", "Name", 99.9m },
                    { 7L, "Category", "Description", "Teste", "Name", 99.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "PRODUCT",
                keyColumn: "id",
                keyValue: 7L);
        }
    }
}
