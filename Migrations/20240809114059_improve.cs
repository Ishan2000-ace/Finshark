using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _NET_Core.Migrations
{
    /// <inheritdoc />
    public partial class improve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833f1d56-7181-4816-93aa-6d1bb29926d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db36b65-281e-4120-ac2f-a75cb2e893e5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72b368e9-3f0e-4b23-8c37-10cc2b150085", null, "User", "User" },
                    { "e266136c-5a10-4987-ac5a-e3a36aa8fd3d", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b368e9-3f0e-4b23-8c37-10cc2b150085");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e266136c-5a10-4987-ac5a-e3a36aa8fd3d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833f1d56-7181-4816-93aa-6d1bb29926d9", null, "User", "User" },
                    { "9db36b65-281e-4120-ac2f-a75cb2e893e5", null, "Admin", "Admin" }
                });
        }
    }
}
