using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class FreshRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aa50983-9899-47bb-b567-f600999e406d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7915b757-cace-4770-aa2f-085b03560cc7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2979192a-91e9-403e-acae-8ef68777375a", "7e625de5-3726-41d7-b1cf-ee40f88e5299", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "808b9b40-d3d6-4004-a10a-00c1ba4d1184", "3663162d-7e38-46f3-b1f5-5c3c5d66f5a5", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2979192a-91e9-403e-acae-8ef68777375a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808b9b40-d3d6-4004-a10a-00c1ba4d1184");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2aa50983-9899-47bb-b567-f600999e406d", "cb3cbf02-8195-4af8-ad80-a926648a720f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7915b757-cace-4770-aa2f-085b03560cc7", "efd7507d-145a-49b8-a733-38367a5251a3", "Member", "MEMBER" });
        }
    }
}
