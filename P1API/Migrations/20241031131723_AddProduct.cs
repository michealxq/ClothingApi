using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P1API.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 8, "Upgrade your wardrobe with our timeless denim jacket. Crafted for durability and style, it's the perfect versatile piece for any occasion.", 35.49m, "Blue breeze jeans jacket", 10 },
                    { 2, 8, "Elevate your style with our premium leather jacket. Crafted from high-quality leather, it offers sleek sophistication and lasting comfort for any occasion.", 80.49m, "Rebel roadster leather jacket", 10 },
                    { 3, 4, "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis.", 40.00m, "City comfort shorts", 10 },
                    { 4, 5, "Introducing our stylish shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.", 105.49m, "Wanderer wave men shirt", 10 },
                    { 5, 2, "Introducing our elegant dress, designed for timeless style and effortless sophistication.", 47.00m, "Bluebird belle dress", 10 },
                    { 6, 8, "Upgrade your wardrobe with our timeless denim jacket. Crafted for durability and style, it's the perfect versatile piece for any occasion.", 95.00m, "Denim delight jacket", 10 },
                    { 7, 8, "Introducing our sleek jacket, crafted for timeless style and enduring comfort.", 105.00m, "Silver shadow jacket", 10 },
                    { 8, 2, "Introducing our sleek sweater, crafted for timeless style and enduring comfort.", 120.49m, "Smoke symphony sweater", 10 },
                    { 9, 8, "Elevate your style with our premium leather jacket. Crafted from high-quality leather, it offers sleek sophistication and lasting comfort for any occasion.", 49.00m, "Caramel charm jacket", 10 },
                    { 10, 3, "Introducing our sleek jacket, crafted for timeless style and enduring comfort.", 120.49m, "Dark knight defender jacket", 10 },
                    { 11, 9, "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos.", 79.49m, "Denim dreamer shorts", 10 },
                    { 12, 12, "Introducing our stylish t-shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.", 33.00m, "Blackbird bloom t-shirt", 10 },
                    { 13, 7, "Introducing our stylish t-shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.", 42.00m, "Midnight majesty t-shirt", 10 },
                    { 14, 3, "Introducing our sleek jacket, crafted for timeless style and enduring comfort.", 35.49m, "Blackout bomber jacket", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);
        }
    }
}
