using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class lalau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ba5c80-eaab-4a2b-8ce3-c00dbd28c752");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d30ebb3-fe9d-482e-8a0f-a7c99eb379e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a06d454-fe5e-49c8-b7ee-97d60bb03cad", "0208f08a-9ad1-459b-80c0-20afcef2a30d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4abccc0e-9589-472a-87d4-249152d7151b", "852a951b-3e61-4d4b-8786-4123c3f5cd7d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a06d454-fe5e-49c8-b7ee-97d60bb03cad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4abccc0e-9589-472a-87d4-249152d7151b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07ba5c80-eaab-4a2b-8ce3-c00dbd28c752", "c89a6d66-feba-4f8b-a33f-b0f2f0b54de9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d30ebb3-fe9d-482e-8a0f-a7c99eb379e2", "9b98a1ce-e274-4de9-ac44-063b79dd5352", "User", "USER" });
        }
    }
}
