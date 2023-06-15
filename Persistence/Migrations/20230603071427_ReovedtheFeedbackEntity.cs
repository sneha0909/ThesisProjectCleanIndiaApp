using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ReovedtheFeedbackEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77959386-8220-4aac-a702-e04fcb4e1dcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eebb49d0-af2a-4e8c-9f3b-8f4333f59808");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61d3ec2b-998c-4857-8d09-17a342c245fd", "8861265a-1b8c-4527-a103-6c13aebdd1ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74c4be0c-6628-4df9-ac3b-c1e7fb4d04c7", "c6731114-c245-48ae-a7cd-935ed4f2918f", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    ComplaintId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77959386-8220-4aac-a702-e04fcb4e1dcc", "c0050e72-ee70-4733-b3d9-5f2672576ac5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eebb49d0-af2a-4e8c-9f3b-8f4333f59808", "5abfdf32-aa34-4e87-8aae-1b4aa768fbc3", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints",
                column: "Id",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }
    }
}
