using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class TranslationEntitiesAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e3b333-701a-4e27-be8b-36f4cdede325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d738ea-5ce2-4916-bc9d-9fe2aa8cf025");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "057454b3-023a-4749-80ad-a43cfde2862c", "ac09b72f-ff14-49b4-b462-70651821ee00", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b6f67d6-4ab3-4113-aea5-840aae4eb065", "ef413459-b52b-4303-81e1-cb4714dc7f18", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057454b3-023a-4749-80ad-a43cfde2862c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b6f67d6-4ab3-4113-aea5-840aae4eb065");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33e3b333-701a-4e27-be8b-36f4cdede325", "0eb3dba6-6371-44d0-8c7f-3d47151cc4c5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41d738ea-5ce2-4916-bc9d-9fe2aa8cf025", "8e575872-30d8-4273-bac8-dab5a0d8f318", "Admin", "ADMIN" });
        }
    }
}
