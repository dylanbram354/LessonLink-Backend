using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class addedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "0508729c-a8a1-45a8-ac94-a85031057650", "1179dfee-047a-4b85-8de3-b3ef150178d2", "User", "USER" },
                    { "1a7e8c12-76c6-4f8b-a8d2-b10f28f01668", "56c116cc-6d75-4ef2-bbeb-bc9ad5b9fa61", "Admin", "ADMIN" },
                    { "48de1dbe-3d23-4557-854a-4ec0bc8fdc2b", "d59f1238-b9b9-4659-a278-877847fefeda", "Teacher", "TEACHER" },
                    { "19603702-5654-473b-838e-c0221530d37e", "82b38c19-e6eb-4dc9-bbc2-615c9856a409", "Student", "STUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0508729c-a8a1-45a8-ac94-a85031057650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19603702-5654-473b-838e-c0221530d37e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7e8c12-76c6-4f8b-a8d2-b10f28f01668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48de1dbe-3d23-4557-854a-4ec0bc8fdc2b");

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
    }
}
