using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d355639-0f35-4ec2-b94c-e04b04a63e6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93a27bde-c22a-47f4-b10c-8f5909a50359");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc0e3076-a5a3-4584-af4b-63189bc9e409", "3c76916a-f36c-47ea-a561-011f0f5e21c0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4c4af15-ed9f-4e41-9617-38e4ffe127e2", "09068515-6189-4ec1-9e7c-e95ec226dedc", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc0e3076-a5a3-4584-af4b-63189bc9e409");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4c4af15-ed9f-4e41-9617-38e4ffe127e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d355639-0f35-4ec2-b94c-e04b04a63e6e", "c5055e84-dff2-4748-81d8-e2b44b7cf820", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93a27bde-c22a-47f4-b10c-8f5909a50359", "39c475fe-fef9-4910-aecf-eb3a50362ccc", "User", "USER" });
        }
    }
}
