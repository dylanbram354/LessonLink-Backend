using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class addedChargeStudentBoolToLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "ChargeStudent",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4929072a-8f8c-47f5-92b1-611aa8e013ee", "7141a467-5975-47a4-9ce6-b0d4a5cb03a8", "User", "USER" },
                    { "e98e99d4-de42-4bcf-9a22-036ec882cd4b", "6c5b8c3a-1448-4140-a306-7098fd2d3334", "Admin", "ADMIN" },
                    { "1cf14e16-2ffa-4f2f-837f-49994caeafa2", "333433cd-963c-4281-91a9-df81a9af78b3", "Teacher", "TEACHER" },
                    { "01a3984d-aa0a-478f-8cfe-96988a6cf2f8", "8fa00270-76af-402e-b4b8-2df2371da345", "Student", "STUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a3984d-aa0a-478f-8cfe-96988a6cf2f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf14e16-2ffa-4f2f-837f-49994caeafa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4929072a-8f8c-47f5-92b1-611aa8e013ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e98e99d4-de42-4bcf-9a22-036ec882cd4b");

            migrationBuilder.DropColumn(
                name: "ChargeStudent",
                table: "Lessons");

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
    }
}
