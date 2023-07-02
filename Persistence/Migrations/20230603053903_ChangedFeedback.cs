using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "7c0e39a7-344d-4001-99f3-752c13000090");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda78bbc-885d-4bfe-b6bf-0efb06ee3d05");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Complaints");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0777cd61-d645-480d-a245-7510a8723f8a", "fc223b92-246b-4bb9-8cdd-fd7ee3d734d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a2cd7d8-ce02-42f4-aebd-88daa9fc514b", "271e59dd-f28f-496c-a834-07847fdbb3e4", "Member", "MEMBER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints",
                column: "Id",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0777cd61-d645-480d-a245-7510a8723f8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a2cd7d8-ce02-42f4-aebd-88daa9fc514b");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c0e39a7-344d-4001-99f3-752c13000090", "f78081fc-9706-4932-907d-91749a2814b5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dda78bbc-885d-4bfe-b6bf-0efb06ee3d05", "bf9f98f6-31a3-435f-ac10-5c42b2e3e945", "Admin", "ADMIN" });

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
    }
}
