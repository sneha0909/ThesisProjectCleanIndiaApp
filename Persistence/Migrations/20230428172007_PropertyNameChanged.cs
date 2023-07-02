using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class PropertyNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cdaea56-d48b-449e-be09-aafed4e35e6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c33c68f-f621-464d-9a9e-130097c8609c");

            migrationBuilder.RenameColumn(
                name: "ComplainantName",
                table: "AspNetUsers",
                newName: "DisplayName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "409428a3-449a-4f92-a2f9-15685b936380", "8f1ba2fe-0562-47f8-af4a-031101024ca9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73f068ef-13ae-43e6-9513-40894adb3003", "6bdf6484-c370-41bb-840c-53227ca2a048", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "409428a3-449a-4f92-a2f9-15685b936380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73f068ef-13ae-43e6-9513-40894adb3003");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "ComplainantName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2cdaea56-d48b-449e-be09-aafed4e35e6d", "cb26ba9a-9374-40d8-af33-09d5920cebc8", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c33c68f-f621-464d-9a9e-130097c8609c", "f4c06952-8c88-4d64-bd3e-14e3cd9fb441", "Admin", "ADMIN" });
        }
    }
}
