using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class addedBalanceToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21b2db4c-4b77-414d-a33f-98b13d7b9055");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "464d771d-ee41-4d28-be62-a69f78418852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d15110-b05d-437e-8887-4c01b6cab69f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7973bb0f-baa4-4268-9384-28e8bb8db134");

            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4cb29e8-878d-489c-a695-4ff676952b11", "f0e64292-16ba-467d-afc0-58539b4ba5d4", "User", "USER" },
                    { "83fc97f1-fc67-4e94-b186-b958391c9b04", "3ff2d26b-c20a-489f-a537-e1c4b7eb3185", "Admin", "ADMIN" },
                    { "d6c50840-dcaa-418b-b99b-28d2e9829527", "01468dcb-f182-4bac-a54f-0f75df60fbf3", "Teacher", "TEACHER" },
                    { "555658b3-daf7-4891-a58c-04a8d1a3684c", "d6f462eb-5bfa-4cf5-a941-b8cad801ceb0", "Student", "STUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "555658b3-daf7-4891-a58c-04a8d1a3684c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83fc97f1-fc67-4e94-b186-b958391c9b04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4cb29e8-878d-489c-a695-4ff676952b11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c50840-dcaa-418b-b99b-28d2e9829527");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "464d771d-ee41-4d28-be62-a69f78418852", "1b020e2a-412d-4e2e-b613-44d4e04c0e06", "User", "USER" },
                    { "21b2db4c-4b77-414d-a33f-98b13d7b9055", "8a1f0782-464e-444c-ab2d-8bd6c51c0af7", "Admin", "ADMIN" },
                    { "69d15110-b05d-437e-8887-4c01b6cab69f", "455feea1-0a5a-45a1-b623-78e3d7d4ae71", "Teacher", "TEACHER" },
                    { "7973bb0f-baa4-4268-9384-28e8bb8db134", "65ea2b56-69b4-4a6b-a7d3-9950005c2ad7", "Student", "STUDENT" }
                });
        }
    }
}
