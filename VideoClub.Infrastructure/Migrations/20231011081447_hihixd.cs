using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class hihixd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bde8e5d-96bb-45d3-b884-1dd9792f8321");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74c920c1-e56c-44ca-a9f7-98f8172ec49d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c63db40-b717-42d4-8ab3-dd279f225fc5", "34f3c7b9-a25d-4e83-bc44-3149dc5860ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84b9c9bb-b44c-408b-bafb-5302126e9175", "46c11e0a-e23b-414e-a88f-6001a7e4709d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3bde8e5d-96bb-45d3-b884-1dd9792f8321", "4ab4f0aa-2d2e-476b-a882-6a93b3711081", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74c920c1-e56c-44ca-a9f7-98f8172ec49d", "2c94d06b-83c0-4754-90d0-8c4c44fe981b", "User", "USER" });
        }
    }
}
