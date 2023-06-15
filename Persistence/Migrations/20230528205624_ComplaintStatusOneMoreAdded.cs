using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ComplaintStatusOneMoreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1317cb0-919e-4a1e-ac11-740694b73be5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0287e63-7edc-434e-b437-5f1c847fda48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6fe7613-5693-48a1-bca0-6477e0909ade", "fcd2ffcf-c7a6-4b50-bcb8-4bd6be43af33", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d104e6c7-6bd9-4427-b990-5ddb0578d0cc", "93a43f98-159c-48af-808c-9eee97d6140b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6fe7613-5693-48a1-bca0-6477e0909ade");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d104e6c7-6bd9-4427-b990-5ddb0578d0cc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1317cb0-919e-4a1e-ac11-740694b73be5", "ffa78287-e3e6-4a52-ba5f-992fa8319480", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0287e63-7edc-434e-b437-5f1c847fda48", "e9d29cab-5589-40d5-942f-150071e60afc", "Member", "MEMBER" });
        }
    }
}
