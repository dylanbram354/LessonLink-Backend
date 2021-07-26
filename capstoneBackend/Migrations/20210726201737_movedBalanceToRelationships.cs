using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class movedBalanceToRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "Relationships",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d553381-71f3-4b63-94e4-07d50089882f", "94517c43-c781-4d5e-94f5-131bb4d53f18", "User", "USER" },
                    { "0679ba61-5a13-4080-8c1a-b133661eb63a", "afc3bc16-6e2a-4d60-8a27-a234c468b747", "Admin", "ADMIN" },
                    { "71d5b2ed-454b-4d45-aac3-e65290cbf462", "1ee591e5-0abc-44af-a18d-19b85bf7a359", "Teacher", "TEACHER" },
                    { "e3f2d883-305f-4695-89e9-5c787198d8bc", "194022f7-4668-44d4-b669-b557b55a7529", "Student", "STUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0679ba61-5a13-4080-8c1a-b133661eb63a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71d5b2ed-454b-4d45-aac3-e65290cbf462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d553381-71f3-4b63-94e4-07d50089882f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3f2d883-305f-4695-89e9-5c787198d8bc");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Relationships");

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
                    { "4929072a-8f8c-47f5-92b1-611aa8e013ee", "7141a467-5975-47a4-9ce6-b0d4a5cb03a8", "User", "USER" },
                    { "e98e99d4-de42-4bcf-9a22-036ec882cd4b", "6c5b8c3a-1448-4140-a306-7098fd2d3334", "Admin", "ADMIN" },
                    { "1cf14e16-2ffa-4f2f-837f-49994caeafa2", "333433cd-963c-4281-91a9-df81a9af78b3", "Teacher", "TEACHER" },
                    { "01a3984d-aa0a-478f-8cfe-96988a6cf2f8", "8fa00270-76af-402e-b4b8-2df2371da345", "Student", "STUDENT" }
                });
        }
    }
}
