using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class _SetupRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a85197de-2346-492e-861e-08b0370b485f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c073f42c-79e8-41a6-a5d7-0ed41ae7aca0");

            migrationBuilder.AddColumn<string>(
                name: "ParentEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredContact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b7784fc-de4d-46d4-8dba-608ca7adfdb0", "84b689a0-94a5-41f8-b7fd-99e211d733c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a177caf6-2a8e-4a72-81e3-c0e9cd7867ce", "a0bcea61-3171-4850-9799-bebdaa835f30", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b7784fc-de4d-46d4-8dba-608ca7adfdb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a177caf6-2a8e-4a72-81e3-c0e9cd7867ce");

            migrationBuilder.DropColumn(
                name: "ParentEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreferredContact",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c073f42c-79e8-41a6-a5d7-0ed41ae7aca0", "df8961da-91f7-4729-a4aa-312b6fcd7c8f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a85197de-2346-492e-861e-08b0370b485f", "27e54b6b-7578-4229-8a3e-7a5a5651df3b", "Admin", "ADMIN" });
        }
    }
}
