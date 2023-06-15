using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class cahngeAgia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a4cc4ade-2ed3-4bcc-b911-4ec11e09f119", "a9c6e5a7-aac6-4017-9fbe-13652d295d69", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc351e6b-cab5-4d2c-883b-38ab39dc453a", "e3b9fa9c-4703-4d05-843d-7baa1a26e229", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4cc4ade-2ed3-4bcc-b911-4ec11e09f119");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc351e6b-cab5-4d2c-883b-38ab39dc453a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c7cfd2c-5f00-4a6c-97d4-60fb8d5dc8f8", "13ff22eb-a586-4648-9282-85b6733591fe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f922d9aa-6f8f-4450-83a1-6b8007c95095", "2ab152c8-b75f-41ad-9f87-f2307208b9d4", "Member", "MEMBER" });
        }
    }
}
