using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ComplaintEntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1f54fe-67a7-45a8-8146-5b6d4a6f3cb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac9947f-fc9a-4282-8402-bd4a25c1582e");

            migrationBuilder.DropColumn(
                name: "ComplainantWard",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantZoneWardNo",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationArea1",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationZoneWardNo",
                table: "Complaints",
                newName: "ComplaintLocationWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationHouseNo",
                table: "Complaints",
                newName: "ComplaintLocationArea");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationAreaInAddress",
                table: "Complaints",
                newName: "ComplainantWardNo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08b124d5-a3bc-49eb-bbef-371cc47feecb", "047ddda5-01c2-4a79-bddb-111e1a163ae2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5fd6177-6ec7-4fc1-80bb-9ab935e155aa", "604d8e6a-e989-4a97-a14a-27235da5e9ce", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08b124d5-a3bc-49eb-bbef-371cc47feecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fd6177-6ec7-4fc1-80bb-9ab935e155aa");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationWardNo",
                table: "Complaints",
                newName: "ComplaintLocationZoneWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationArea",
                table: "Complaints",
                newName: "ComplaintLocationHouseNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantWardNo",
                table: "Complaints",
                newName: "ComplaintLocationAreaInAddress");

            migrationBuilder.AddColumn<string>(
                name: "ComplainantWard",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantZoneWardNo",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationArea1",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e1f54fe-67a7-45a8-8146-5b6d4a6f3cb8", "1ac3d177-0306-43da-8b7e-a4f8d9acdb63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ac9947f-fc9a-4282-8402-bd4a25c1582e", "5bf393f0-dcc4-4c8a-be2e-de1cbb217a59", "Member", "MEMBER" });
        }
    }
}
