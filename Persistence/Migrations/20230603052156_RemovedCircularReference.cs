using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemovedCircularReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Complaints_ComplaintId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ComplaintId",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2979192a-91e9-403e-acae-8ef68777375a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808b9b40-d3d6-4004-a10a-00c1ba4d1184");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fc0d97e-e08e-4b54-be1c-09fa2b925501", "92e6f80b-b710-41fa-9a79-022425fb8085", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ffd66e3-a03b-4187-9a7b-3809785c5009", "2b4874f8-cbf8-4d46-afd3-517be02d0ece", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_FeedbackId",
                table: "Complaints",
                column: "FeedbackId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_FeedbackId",
                table: "Complaints",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_FeedbackId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_FeedbackId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fc0d97e-e08e-4b54-be1c-09fa2b925501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ffd66e3-a03b-4187-9a7b-3809785c5009");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Complaints");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2979192a-91e9-403e-acae-8ef68777375a", "7e625de5-3726-41d7-b1cf-ee40f88e5299", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "808b9b40-d3d6-4004-a10a-00c1ba4d1184", "3663162d-7e38-46f3-b1f5-5c3c5d66f5a5", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ComplaintId",
                table: "Feedbacks",
                column: "ComplaintId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Complaints_ComplaintId",
                table: "Feedbacks",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
