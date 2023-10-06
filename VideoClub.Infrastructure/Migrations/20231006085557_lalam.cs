using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class lalam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64927ec0-d564-434e-9536-1c5ad50533c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff9840c3-8301-48ba-9aef-b7dca56a30c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6614bb4c-0a01-452f-8182-a4d68d2d171e", "7b0f2de2-0390-4215-9645-1a8560c02065", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e60a4ef4-ceea-4a66-b73b-266587309e07", "0b4b983a-ff73-48fd-99ac-7f057b39ad48", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6614bb4c-0a01-452f-8182-a4d68d2d171e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60a4ef4-ceea-4a66-b73b-266587309e07");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64927ec0-d564-434e-9536-1c5ad50533c4", "86346432-b4fe-4230-8fff-61d4dc2630bf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff9840c3-8301-48ba-9aef-b7dca56a30c9", "427873ac-b414-4b50-a0b6-72ba26f35d2a", "User", "USER" });
        }
    }
}
