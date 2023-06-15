using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddullabletoForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b406134-91d4-4b9d-8b0a-ba4cb63aada1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eed001f9-ec60-4416-9314-40bcbc5ede45");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComplaintId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02f7d47c-cba8-4cb6-b524-57090e814daa", "9f823cc6-81f0-40b7-ac73-312d396becc0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb64024f-d842-4bcd-8dbf-da80a9ed6e06", "69ef6ee2-a3c3-4226-9316-50034be841a6", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f7d47c-cba8-4cb6-b524-57090e814daa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb64024f-d842-4bcd-8dbf-da80a9ed6e06");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComplaintId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b406134-91d4-4b9d-8b0a-ba4cb63aada1", "704e42dc-cca2-47d4-9a97-3a92cd4c2a04", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eed001f9-ec60-4416-9314-40bcbc5ede45", "67220bc1-89fe-418d-b0a3-6d1c30c47ada", "Member", "MEMBER" });
        }
    }
}
