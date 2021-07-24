using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class _SeedRolesAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b7784fc-de4d-46d4-8dba-608ca7adfdb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a177caf6-2a8e-4a72-81e3-c0e9cd7867ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad1f2ee4-9a35-4b20-b285-d29c4f202962", "130ce496-6236-4593-a9e5-9eb27d4674ed", "User", "USER" },
                    { "7ef3e53d-6479-428a-85ca-086a21afe4bc", "f6c552b0-4a2a-4f84-8a41-0a74bb5bbf52", "Admin", "ADMIN" },
                    { "ef2d4fe3-551a-467a-a839-b2f7e7c0ca79", "2e0ca5ee-22e6-4278-89b6-b717d97d9e13", "Teacher", "TEACHER" },
                    { "24e23253-cd89-48ad-ae95-1bca9bd5c2a1", "4832965d-8224-4b46-bb26-b0cb03c4a026", "Student", "STUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24e23253-cd89-48ad-ae95-1bca9bd5c2a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef3e53d-6479-428a-85ca-086a21afe4bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad1f2ee4-9a35-4b20-b285-d29c4f202962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef2d4fe3-551a-467a-a839-b2f7e7c0ca79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b7784fc-de4d-46d4-8dba-608ca7adfdb0", "84b689a0-94a5-41f8-b7fd-99e211d733c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a177caf6-2a8e-4a72-81e3-c0e9cd7867ce", "a0bcea61-3171-4850-9799-bebdaa835f30", "Admin", "ADMIN" });
        }
    }
}
