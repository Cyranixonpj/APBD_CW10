using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[,]
                {
                    { 1, 24.0m, 2.0m, "Laptop", 2.5m, 35.5m },
                    { 2, 14.0m, 0.8m, "Smartphone", 0.2m, 7.0m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "last_name", "FK_role", "phone" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", 1, "123456789" },
                    { 2, "jane.doe@example.com", "Jane", "Doe", 2, "987654321" }
                });

            migrationBuilder.InsertData(
                table: "ProductsCategories",
                columns: new[] { "FK_category", "FK_product" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "FK_account", "FK_product", "amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 2);
        }
    }
}
