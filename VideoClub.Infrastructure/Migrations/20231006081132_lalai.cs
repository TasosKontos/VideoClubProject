using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Infrastructure.Migrations
{
    public partial class lalai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieCopies_MovieCopyId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a06d454-fe5e-49c8-b7ee-97d60bb03cad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4abccc0e-9589-472a-87d4-249152d7151b");

            migrationBuilder.AlterColumn<int>(
                name: "MovieCopyId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03e6d13b-3206-4090-a160-392a89560efe", "a51c3a87-8b8f-480d-ba26-48e250bdc577", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5266e77-e514-4880-b020-9cdcf566b61b", "e34de5e9-b1d4-45c3-a796-0500dae5bd96", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieCopies_MovieCopyId",
                table: "Reservations",
                column: "MovieCopyId",
                principalTable: "MovieCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieCopies_MovieCopyId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e6d13b-3206-4090-a160-392a89560efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5266e77-e514-4880-b020-9cdcf566b61b");

            migrationBuilder.AlterColumn<int>(
                name: "MovieCopyId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a06d454-fe5e-49c8-b7ee-97d60bb03cad", "0208f08a-9ad1-459b-80c0-20afcef2a30d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4abccc0e-9589-472a-87d4-249152d7151b", "852a951b-3e61-4d4b-8786-4123c3f5cd7d", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieCopies_MovieCopyId",
                table: "Reservations",
                column: "MovieCopyId",
                principalTable: "MovieCopies",
                principalColumn: "Id");
        }
    }
}
