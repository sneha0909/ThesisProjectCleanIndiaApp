using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedJsonIgnore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e53fc17-4d60-412f-8b9a-a86f9a77f8cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84490bd6-1245-49aa-9a0f-a89939067f83");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aea78c5e-ed72-42a3-9511-de2bdda6e5f9", "07180ad7-6d76-453f-927d-b4c295623981", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff4fa70d-f7af-4458-954e-af6d2cd3eabc", "bb3acccd-f88a-4bf6-a14b-3070bf08763a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea78c5e-ed72-42a3-9511-de2bdda6e5f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff4fa70d-f7af-4458-954e-af6d2cd3eabc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e53fc17-4d60-412f-8b9a-a86f9a77f8cc", "dcd7d11c-9c67-4195-b8bb-cb83d9a7b813", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84490bd6-1245-49aa-9a0f-a89939067f83", "80afa142-3d7a-4827-b970-86272aa4cc09", "Member", "MEMBER" });
        }
    }
}
