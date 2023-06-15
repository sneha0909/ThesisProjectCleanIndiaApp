using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemovedCircularRefererence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId1",
                table: "TranslatedComplaints");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedComplaints_ComplaintId1",
                table: "TranslatedComplaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa9eff29-dbaf-42bd-aac9-d5f6cacc394c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5c95062-d275-414c-9d83-21d01bda0c61");

            migrationBuilder.DropColumn(
                name: "ComplaintId1",
                table: "TranslatedComplaints");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e53fc17-4d60-412f-8b9a-a86f9a77f8cc", "dcd7d11c-9c67-4195-b8bb-cb83d9a7b813", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84490bd6-1245-49aa-9a0f-a89939067f83", "80afa142-3d7a-4827-b970-86272aa4cc09", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e53fc17-4d60-412f-8b9a-a86f9a77f8cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84490bd6-1245-49aa-9a0f-a89939067f83");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintId1",
                table: "TranslatedComplaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa9eff29-dbaf-42bd-aac9-d5f6cacc394c", "18638bad-c734-455d-8dee-08725e51e764", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5c95062-d275-414c-9d83-21d01bda0c61", "5970aa70-7d9b-4454-b795-454020c8a4df", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaints_ComplaintId1",
                table: "TranslatedComplaints",
                column: "ComplaintId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId1",
                table: "TranslatedComplaints",
                column: "ComplaintId1",
                principalTable: "Complaints",
                principalColumn: "Id");
        }
    }
}
