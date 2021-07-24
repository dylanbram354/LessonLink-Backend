using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneBackend.Migrations
{
    public partial class addedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoogleEventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleRecurringId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAmount = table.Column<float>(type: "real", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isNoShow = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    MethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RelationshipId",
                table: "Documents",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_RelationshipId",
                table: "Lessons",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MethodId",
                table: "Payments",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RelationshipId",
                table: "Payments",
                column: "RelationshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

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
        }
    }
}
