using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class BioPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c37e96-3ff7-4f9d-82c7-c4eb99a93242");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ffd5058-dd6f-4253-ad98-cd39c96053e0");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bb3133d-e208-4d45-baaf-bba9f60f6eb9", "31259460-e8e5-49f1-8c71-cdcc9d80ffa9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36758a37-6a15-40f2-b815-53181f31aaa4", "e26564c6-9e04-408a-82d4-29da85a469ed", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bb3133d-e208-4d45-baaf-bba9f60f6eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36758a37-6a15-40f2-b815-53181f31aaa4");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39c37e96-3ff7-4f9d-82c7-c4eb99a93242", "d261609a-351d-4e37-9acc-41fc01c0c353", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ffd5058-dd6f-4253-ad98-cd39c96053e0", "34a2daf8-d95e-4be1-bd60-a0ddc9aec6ce", "Admin", "ADMIN" });
        }
    }
}
