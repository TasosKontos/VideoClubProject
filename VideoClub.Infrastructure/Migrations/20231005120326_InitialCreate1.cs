using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0501d920-8ba0-4b9b-ae57-ce8954d15a50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1167164-6a24-4c36-9a81-e9e6ff263c79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d355639-0f35-4ec2-b94c-e04b04a63e6e", "c5055e84-dff2-4748-81d8-e2b44b7cf820", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93a27bde-c22a-47f4-b10c-8f5909a50359", "39c475fe-fef9-4910-aecf-eb3a50362ccc", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0501d920-8ba0-4b9b-ae57-ce8954d15a50", "7dff02b1-0700-45f0-b30a-a54cf3edf92b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1167164-6a24-4c36-9a81-e9e6ff263c79", "ced660c6-8d5c-40be-ab52-806bf65e7876", "User", "USER" });
        }
    }
}
