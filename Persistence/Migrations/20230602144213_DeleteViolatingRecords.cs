using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class DeleteViolatingRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d761570-86e8-42e4-9ba8-d99d3bc1af1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93af60a6-b9f1-4a3a-b9f0-a7851cc5c70c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2aa50983-9899-47bb-b567-f600999e406d", "cb3cbf02-8195-4af8-ad80-a926648a720f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7915b757-cace-4770-aa2f-085b03560cc7", "efd7507d-145a-49b8-a733-38367a5251a3", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aa50983-9899-47bb-b567-f600999e406d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7915b757-cace-4770-aa2f-085b03560cc7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d761570-86e8-42e4-9ba8-d99d3bc1af1c", "402764e7-43cb-482a-a3b6-16fe520ef762", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93af60a6-b9f1-4a3a-b9f0-a7851cc5c70c", "9557aab3-f573-4e93-8f2d-8ac7d7ebaa39", "Admin", "ADMIN" });
        }
    }
}
