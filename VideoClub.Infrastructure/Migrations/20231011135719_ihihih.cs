using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class ihihih : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c63db40-b717-42d4-8ab3-dd279f225fc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b9c9bb-b44c-408b-bafb-5302126e9175");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b042f85-d796-46ba-ad95-8a14544381e7", "89433da4-da75-42ac-84f9-3cea4a0eea3f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87cdf833-4604-4585-9aca-467278337e1e", "18998e8c-20e2-458a-aba6-a482c3f3163c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b042f85-d796-46ba-ad95-8a14544381e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87cdf833-4604-4585-9aca-467278337e1e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c63db40-b717-42d4-8ab3-dd279f225fc5", "34f3c7b9-a25d-4e83-bc44-3149dc5860ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84b9c9bb-b44c-408b-bafb-5302126e9175", "46c11e0a-e23b-414e-a88f-6001a7e4709d", "Admin", "ADMIN" });
        }
    }
}
