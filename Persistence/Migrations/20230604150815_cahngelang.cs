using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class cahngelang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1c0ffc80-c2eb-41e0-9202-a1622aa0814c", "f083b17c-e7c3-48d8-8ae4-ef21d1d0888a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99c18bb7-6ecc-44cf-8490-9949618d7ba4", "2b89ac1d-e583-49c2-aef8-c6bcb5460213", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c0ffc80-c2eb-41e0-9202-a1622aa0814c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c18bb7-6ecc-44cf-8490-9949618d7ba4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4cc4ade-2ed3-4bcc-b911-4ec11e09f119", "a9c6e5a7-aac6-4017-9fbe-13652d295d69", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc351e6b-cab5-4d2c-883b-38ab39dc453a", "e3b9fa9c-4703-4d05-843d-7baa1a26e229", "Admin", "ADMIN" });
        }
    }
}
