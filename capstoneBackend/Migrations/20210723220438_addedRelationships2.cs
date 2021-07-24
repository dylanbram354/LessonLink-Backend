using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class addedRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_Relationships_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relationships_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02aef1dd-b475-4890-881d-ad5c502f6ddc", "76d9333c-4c65-4cc4-a03b-bdb62d39cdc4", "User", "USER" },
                    { "9e9abba1-05e9-4bf6-ab7c-5ffa2cf772f5", "414f7a5b-f9ee-433d-ba17-311e2a01c4b0", "Admin", "ADMIN" },
                    { "2e136658-2afa-49bc-81eb-cff73a1383b7", "d952d580-b1c8-4f96-87f4-c727925bfae7", "Teacher", "TEACHER" },
                    { "55c74ed6-cd7e-4015-89bb-1c79a2b0f62f", "999e9b7d-38fb-496e-b1ca-b2cec8c79816", "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_StudentId",
                table: "Relationships",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_TeacherId",
                table: "Relationships",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02aef1dd-b475-4890-881d-ad5c502f6ddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e136658-2afa-49bc-81eb-cff73a1383b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55c74ed6-cd7e-4015-89bb-1c79a2b0f62f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9abba1-05e9-4bf6-ab7c-5ffa2cf772f5");

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
    }
}
