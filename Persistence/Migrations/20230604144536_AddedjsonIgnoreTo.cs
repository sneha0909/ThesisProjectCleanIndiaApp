using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedjsonIgnoreTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b568fe7-a3c4-45b9-8177-721d64192688");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b64b0fd-63dc-4c8e-9f2c-5da989180bed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c7cfd2c-5f00-4a6c-97d4-60fb8d5dc8f8", "13ff22eb-a586-4648-9282-85b6733591fe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f922d9aa-6f8f-4450-83a1-6b8007c95095", "2ab152c8-b75f-41ad-9f87-f2307208b9d4", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c7cfd2c-5f00-4a6c-97d4-60fb8d5dc8f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f922d9aa-6f8f-4450-83a1-6b8007c95095");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b568fe7-a3c4-45b9-8177-721d64192688", "266275f7-3ed8-4a2b-9b45-aa5687180cea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b64b0fd-63dc-4c8e-9f2c-5da989180bed", "b8486092-929a-4dff-b71a-f435abccdde2", "Member", "MEMBER" });
        }
    }
}
