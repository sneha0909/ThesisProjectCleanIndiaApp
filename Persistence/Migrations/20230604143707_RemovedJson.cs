using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemovedJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3b568fe7-a3c4-45b9-8177-721d64192688", "266275f7-3ed8-4a2b-9b45-aa5687180cea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b64b0fd-63dc-4c8e-9f2c-5da989180bed", "b8486092-929a-4dff-b71a-f435abccdde2", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "5fa8552e-e416-4f4e-ab8c-f0ada1fb3ba8", "6343e4ab-cc69-4567-960a-342ef5508939", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87fb402f-d8e2-4e7b-9d85-c78622e4f5d0", "039b3c75-bce8-4326-8f30-f79fa406598b", "Member", "MEMBER" });
        }
    }
}
