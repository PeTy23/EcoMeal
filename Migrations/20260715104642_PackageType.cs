using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoMeal.Migrations
{
    /// <inheritdoc />
    public partial class PackageType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PackageTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Bakery" },
                    { 1, "Beverage" },
                    { 2, "Dairy" },
                    { 3, "Frozen Food" },
                    { 4, "Meat" },
                    { 5, "Produce" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
