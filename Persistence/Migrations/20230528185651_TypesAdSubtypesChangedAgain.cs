using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class TypesAdSubtypesChangedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5693f4f-fee5-4d5f-b347-77fd33b93b4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfa25ca5-f000-484b-ae40-eaaf214f1954");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1317cb0-919e-4a1e-ac11-740694b73be5", "ffa78287-e3e6-4a52-ba5f-992fa8319480", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0287e63-7edc-434e-b437-5f1c847fda48", "e9d29cab-5589-40d5-942f-150071e60afc", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1317cb0-919e-4a1e-ac11-740694b73be5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0287e63-7edc-434e-b437-5f1c847fda48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5693f4f-fee5-4d5f-b347-77fd33b93b4f", "d8ddfffc-9851-4185-be2b-11f08fe93797", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfa25ca5-f000-484b-ae40-eaaf214f1954", "c78fbe04-46a7-4d0c-aba5-31123b57db98", "Member", "MEMBER" });
        }
    }
}
