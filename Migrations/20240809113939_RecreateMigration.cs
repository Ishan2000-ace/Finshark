using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _NET_Core.Migrations
{
    /// <inheritdoc />
    public partial class RecreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8737b204-af32-4ebe-94fd-512859de0e04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd450c03-7c2a-4479-8e53-fe638aaff872");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833f1d56-7181-4816-93aa-6d1bb29926d9", null, "User", "User" },
                    { "9db36b65-281e-4120-ac2f-a75cb2e893e5", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "8737b204-af32-4ebe-94fd-512859de0e04", null, "Admin", "Admin" },
                    { "bd450c03-7c2a-4479-8e53-fe638aaff872", null, "User", "User" }
                });
        }
    }
}
