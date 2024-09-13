using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _NET_Core.Migrations
{
    /// <inheritdoc />
    public partial class onetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_UserCommentIDId",
                table: "comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002df483-4564-4ee9-aa43-4a7558cb9178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3698d2d-d702-42fe-be11-c73b7d51773f");

            migrationBuilder.RenameColumn(
                name: "UserCommentIDId",
                table: "comments",
                newName: "Id1");

            migrationBuilder.RenameIndex(
                name: "IX_comments_UserCommentIDId",
                table: "comments",
                newName: "IX_comments_Id1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8737b204-af32-4ebe-94fd-512859de0e04", null, "Admin", "Admin" },
                    { "bd450c03-7c2a-4479-8e53-fe638aaff872", null, "User", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_Id1",
                table: "comments",
                column: "Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_Id1",
                table: "comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8737b204-af32-4ebe-94fd-512859de0e04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd450c03-7c2a-4479-8e53-fe638aaff872");

            migrationBuilder.RenameColumn(
                name: "Id1",
                table: "comments",
                newName: "UserCommentIDId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_Id1",
                table: "comments",
                newName: "IX_comments_UserCommentIDId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "002df483-4564-4ee9-aa43-4a7558cb9178", null, "Admin", "Admin" },
                    { "a3698d2d-d702-42fe-be11-c73b7d51773f", null, "User", "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_UserCommentIDId",
                table: "comments",
                column: "UserCommentIDId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
