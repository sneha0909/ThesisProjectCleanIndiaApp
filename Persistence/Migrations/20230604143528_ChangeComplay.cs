using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangeComplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a3a958-a069-485e-aee9-fcf02e478198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78084b32-a141-40a5-9da7-9f288d254ef5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fa8552e-e416-4f4e-ab8c-f0ada1fb3ba8", "6343e4ab-cc69-4567-960a-342ef5508939", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87fb402f-d8e2-4e7b-9d85-c78622e4f5d0", "039b3c75-bce8-4326-8f30-f79fa406598b", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fa8552e-e416-4f4e-ab8c-f0ada1fb3ba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87fb402f-d8e2-4e7b-9d85-c78622e4f5d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22a3a958-a069-485e-aee9-fcf02e478198", "c4964b15-80ad-42bf-a530-a332a34e1120", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78084b32-a141-40a5-9da7-9f288d254ef5", "a0572271-799d-40b2-944b-f23ad2e8a470", "Admin", "ADMIN" });
        }
    }
}
