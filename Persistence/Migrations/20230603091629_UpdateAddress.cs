using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cc7cc9b-5232-4d85-8a4d-bc590d1a87d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b932b8-b09b-4745-a093-ec46a844d71a");

            migrationBuilder.AddColumn<string>(
                name: "ComplainantLocationArea",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantLocationHouseName",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantLocationHouseNo",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantLocationLandmark",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantWardNo",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationArea",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationLandmark",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintWardNo",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fecafa5-5012-4cd9-96fe-7074addbff57", "5dd44951-c575-4261-af8d-3ccf55ecdd2a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70838644-9e88-46bb-a337-ae89522271d0", "154492b4-5c21-40c5-8acc-0f296f462dda", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fecafa5-5012-4cd9-96fe-7074addbff57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70838644-9e88-46bb-a337-ae89522271d0");

            migrationBuilder.DropColumn(
                name: "ComplainantLocationArea",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplainantLocationHouseName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplainantLocationHouseNo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplainantLocationLandmark",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplainantWardNo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationArea",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationLandmark",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComplaintWardNo",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cc7cc9b-5232-4d85-8a4d-bc590d1a87d6", "f233abf0-4b1c-4661-91f0-74d22eecd5ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1b932b8-b09b-4745-a093-ec46a844d71a", "d84bbba8-76d0-4cb8-90c8-0002f6ffd9cb", "Member", "MEMBER" });
        }
    }
}
