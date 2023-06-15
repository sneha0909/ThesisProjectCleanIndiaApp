using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedAddressConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af979ab0-ddc9-441c-b3d8-4b7ae8b8ce21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd830cfb-1e5f-4aa4-9dae-2afee154368c");

            migrationBuilder.AddColumn<string>(
                name: "AddressType",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                values: new object[] { "84455f24-2acd-4502-919a-a8ffbe50eb84", "f461cc62-40b2-4802-9017-d47f2cde7c9b", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1540805-2213-49eb-ba22-d6984f00805d", "7cd271b0-8914-4842-864b-ff79c48a4724", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84455f24-2acd-4502-919a-a8ffbe50eb84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1540805-2213-49eb-ba22-d6984f00805d");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Addresses");

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
                values: new object[] { "af979ab0-ddc9-441c-b3d8-4b7ae8b8ce21", "ffc90cd9-108c-4a08-8f32-aded237dea58", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd830cfb-1e5f-4aa4-9dae-2afee154368c", "4e9437fa-2d94-435c-a6c8-f42598f1a041", "Admin", "ADMIN" });
        }
    }
}
