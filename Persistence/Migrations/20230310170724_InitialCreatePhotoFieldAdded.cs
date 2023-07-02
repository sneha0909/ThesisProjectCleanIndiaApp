using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreatePhotoFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06123be7-e349-4692-9607-be4500ba6d07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ca9182-93cd-4bbd-a3ad-4bfbeda38442");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71af6cd1-abde-434f-8903-787c48e64ddc", "12440688-74f1-4b9c-a18d-383c58a2aec2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3f0d336-fbda-43d5-b5c7-71548f0e744f", "9ce29462-120f-4475-8e55-5b8a4a799a9d", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71af6cd1-abde-434f-8903-787c48e64ddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3f0d336-fbda-43d5-b5c7-71548f0e744f");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Complaints");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06123be7-e349-4692-9607-be4500ba6d07", "15fbf351-b6eb-4d0e-a8bd-65efc3c9fae3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77ca9182-93cd-4bbd-a3ad-4bfbeda38442", "5c06e687-b231-4f14-9477-ba509347d2db", "Member", "MEMBER" });
        }
    }
}
