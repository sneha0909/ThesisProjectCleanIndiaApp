using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AgainTryingFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61d3ec2b-998c-4857-8d09-17a342c245fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74c4be0c-6628-4df9-ac3b-c1e7fb4d04c7");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cc7cc9b-5232-4d85-8a4d-bc590d1a87d6", "f233abf0-4b1c-4661-91f0-74d22eecd5ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1b932b8-b09b-4745-a093-ec46a844d71a", "d84bbba8-76d0-4cb8-90c8-0002f6ffd9cb", "Member", "MEMBER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints",
                column: "Id",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cc7cc9b-5232-4d85-8a4d-bc590d1a87d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b932b8-b09b-4745-a093-ec46a844d71a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61d3ec2b-998c-4857-8d09-17a342c245fd", "8861265a-1b8c-4527-a103-6c13aebdd1ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74c4be0c-6628-4df9-ac3b-c1e7fb4d04c7", "c6731114-c245-48ae-a7cd-935ed4f2918f", "Member", "MEMBER" });
        }
    }
}
