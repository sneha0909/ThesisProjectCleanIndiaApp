using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddullabletoFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c4719dd-3bc5-40cf-8ece-4d1379b3c0ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "758d8360-17f9-40d5-b6d1-6eec2770137a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b406134-91d4-4b9d-8b0a-ba4cb63aada1", "704e42dc-cca2-47d4-9a97-3a92cd4c2a04", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eed001f9-ec60-4416-9314-40bcbc5ede45", "67220bc1-89fe-418d-b0a3-6d1c30c47ada", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b406134-91d4-4b9d-8b0a-ba4cb63aada1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed001f9-ec60-4416-9314-40bcbc5ede45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c4719dd-3bc5-40cf-8ece-4d1379b3c0ac", "33627c1e-7c8f-4946-b4ad-44d67551c119", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "758d8360-17f9-40d5-b6d1-6eec2770137a", "70c2a2db-9b3f-46db-b04a-30dbf35ba7b8", "Member", "MEMBER" });
        }
    }
}
