using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Addedullalenaviagation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "380e17e7-7941-4c6c-9d77-9c2714ea3dba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b04be2-4502-481a-9f41-d5c94d6521ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77959386-8220-4aac-a702-e04fcb4e1dcc", "c0050e72-ee70-4733-b3d9-5f2672576ac5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eebb49d0-af2a-4e8c-9f3b-8f4333f59808", "5abfdf32-aa34-4e87-8aae-1b4aa768fbc3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77959386-8220-4aac-a702-e04fcb4e1dcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eebb49d0-af2a-4e8c-9f3b-8f4333f59808");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "380e17e7-7941-4c6c-9d77-9c2714ea3dba", "32c92ec1-53ae-4def-bca9-45514af4af68", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78b04be2-4502-481a-9f41-d5c94d6521ab", "c44feb59-5795-4e32-9c9b-b158577f1b98", "Admin", "ADMIN" });
        }
    }
}
