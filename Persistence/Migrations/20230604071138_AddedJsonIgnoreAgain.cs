using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedJsonIgnoreAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "af979ab0-ddc9-441c-b3d8-4b7ae8b8ce21", "ffc90cd9-108c-4a08-8f32-aded237dea58", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd830cfb-1e5f-4aa4-9dae-2afee154368c", "4e9437fa-2d94-435c-a6c8-f42598f1a041", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af979ab0-ddc9-441c-b3d8-4b7ae8b8ce21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd830cfb-1e5f-4aa4-9dae-2afee154368c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aea78c5e-ed72-42a3-9511-de2bdda6e5f9", "07180ad7-6d76-453f-927d-b4c295623981", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff4fa70d-f7af-4458-954e-af6d2cd3eabc", "bb3acccd-f88a-4bf6-a14b-3070bf08763a", "Admin", "ADMIN" });
        }
    }
}
