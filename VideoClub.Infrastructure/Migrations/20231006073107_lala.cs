using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class lala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9afac448-25f7-4189-acff-0ac6f47dde28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a80ab6-2524-487a-a76b-cbfb4cf29359");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07ba5c80-eaab-4a2b-8ce3-c00dbd28c752", "c89a6d66-feba-4f8b-a33f-b0f2f0b54de9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d30ebb3-fe9d-482e-8a0f-a7c99eb379e2", "9b98a1ce-e274-4de9-ac44-063b79dd5352", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9afac448-25f7-4189-acff-0ac6f47dde28", "56c61a01-01b3-4b21-848c-9741be840132", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8a80ab6-2524-487a-a76b-cbfb4cf29359", "f6e3501b-77a5-40d2-86ef-a10d2bd4beed", "Admin", "ADMIN" });
        }
    }
}
