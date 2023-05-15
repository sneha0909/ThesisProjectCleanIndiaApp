using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddCancelledproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2432cad9-7ec2-45a6-874b-dbf8552b061f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9261c2dd-5c1a-452f-b86d-77df45b4b2bf");

            migrationBuilder.AddColumn<bool>(
                name: "isCancelled",
                table: "CleaningEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2cdaea56-d48b-449e-be09-aafed4e35e6d", "cb26ba9a-9374-40d8-af33-09d5920cebc8", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c33c68f-f621-464d-9a9e-130097c8609c", "f4c06952-8c88-4d64-bd3e-14e3cd9fb441", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cdaea56-d48b-449e-be09-aafed4e35e6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c33c68f-f621-464d-9a9e-130097c8609c");

            migrationBuilder.DropColumn(
                name: "isCancelled",
                table: "CleaningEvents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2432cad9-7ec2-45a6-874b-dbf8552b061f", "9670d34d-3e7b-4748-b691-0e963178d19a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9261c2dd-5c1a-452f-b86d-77df45b4b2bf", "6d02c711-1f02-43a8-9202-67e900d15c81", "Admin", "ADMIN" });
        }
    }
}
