using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class lalak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e6d13b-3206-4090-a160-392a89560efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5266e77-e514-4880-b020-9cdcf566b61b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64927ec0-d564-434e-9536-1c5ad50533c4", "86346432-b4fe-4230-8fff-61d4dc2630bf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff9840c3-8301-48ba-9aef-b7dca56a30c9", "427873ac-b414-4b50-a0b6-72ba26f35d2a", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "03e6d13b-3206-4090-a160-392a89560efe", "a51c3a87-8b8f-480d-ba26-48e250bdc577", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5266e77-e514-4880-b020-9cdcf566b61b", "e34de5e9-b1d4-45c3-a796-0500dae5bd96", "Admin", "ADMIN" });
        }
    }
}
