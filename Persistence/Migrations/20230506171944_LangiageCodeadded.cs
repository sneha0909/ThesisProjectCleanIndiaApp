using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class LangiageCodeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "409428a3-449a-4f92-a2f9-15685b936380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73f068ef-13ae-43e6-9513-40894adb3003");

            migrationBuilder.AddColumn<bool>(
                name: "LanguageCode",
                table: "CleaningEventAttendees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c810d6d1-7ea1-44ae-93db-f7166e8557be", "27e4a4b0-366d-41c4-a6a2-762f93310332", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e07a8dd4-ba9d-46e5-a470-8f90efcba947", "9c3bf951-79e9-4c66-9de1-224e48693c0e", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c810d6d1-7ea1-44ae-93db-f7166e8557be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e07a8dd4-ba9d-46e5-a470-8f90efcba947");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "CleaningEventAttendees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "409428a3-449a-4f92-a2f9-15685b936380", "8f1ba2fe-0562-47f8-af4a-031101024ca9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73f068ef-13ae-43e6-9513-40894adb3003", "6bdf6484-c370-41bb-840c-53227ca2a048", "Admin", "ADMIN" });
        }
    }
}
