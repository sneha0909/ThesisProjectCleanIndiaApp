using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedFeedbackAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0777cd61-d645-480d-a245-7510a8723f8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a2cd7d8-ce02-42f4-aebd-88daa9fc514b");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c4719dd-3bc5-40cf-8ece-4d1379b3c0ac", "33627c1e-7c8f-4946-b4ad-44d67551c119", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "758d8360-17f9-40d5-b6d1-6eec2770137a", "70c2a2db-9b3f-46db-b04a-30dbf35ba7b8", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c4719dd-3bc5-40cf-8ece-4d1379b3c0ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "758d8360-17f9-40d5-b6d1-6eec2770137a");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "Feedbacks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0777cd61-d645-480d-a245-7510a8723f8a", "fc223b92-246b-4bb9-8cdd-fd7ee3d734d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a2cd7d8-ce02-42f4-aebd-88daa9fc514b", "271e59dd-f28f-496c-a834-07847fdbb3e4", "Member", "MEMBER" });
        }
    }
}
