using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SettingComplaintlangauge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c0ffc80-c2eb-41e0-9202-a1622aa0814c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c18bb7-6ecc-44cf-8490-9949618d7ba4");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AddressTranslations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "072b66a7-71a4-4b22-996a-2c032632e3a0", "1788c948-883f-40c6-aab3-568392f7c380", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53417e20-8f9e-4f8f-b5f2-84ca7a49d784", "34e555a0-c6b2-4f15-9935-cd32f5f31882", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "072b66a7-71a4-4b22-996a-2c032632e3a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53417e20-8f9e-4f8f-b5f2-84ca7a49d784");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AddressTranslations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c0ffc80-c2eb-41e0-9202-a1622aa0814c", "f083b17c-e7c3-48d8-8ae4-ef21d1d0888a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99c18bb7-6ecc-44cf-8490-9949618d7ba4", "2b89ac1d-e583-49c2-aef8-c6bcb5460213", "Member", "MEMBER" });
        }
    }
}
