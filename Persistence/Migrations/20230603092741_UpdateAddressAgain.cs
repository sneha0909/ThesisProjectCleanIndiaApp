using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateAddressAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b9fec076-50d9-441e-84c1-9f0c4b7d9610", "0478d778-2dd2-4e69-8f1d-7759c47b009a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3077135-5a13-4982-ad13-a4f4014ec732", "2f31c8bc-10c3-4224-962d-1832397d2438", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9fec076-50d9-441e-84c1-9f0c4b7d9610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3077135-5a13-4982-ad13-a4f4014ec732");

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
    }
}
