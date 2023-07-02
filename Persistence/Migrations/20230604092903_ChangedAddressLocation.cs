using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedAddressLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ComplainantLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComplainantWardNo = table.Column<string>(type: "TEXT", nullable: true),
                    ComplainantLocationHouseNo = table.Column<string>(type: "TEXT", nullable: true),
                    ComplainantLocationHouseName = table.Column<string>(type: "TEXT", nullable: true),
                    ComplainantLocationLandmark = table.Column<string>(type: "TEXT", nullable: true),
                    ComplainantLocationArea = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainantLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplainantLocations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComplaintWardNo = table.Column<string>(type: "TEXT", nullable: true),
                    ComplaintLocationArea = table.Column<string>(type: "TEXT", nullable: true),
                    ComplaintLocationLandmark = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintLocations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0972f9f-508d-4437-9dd4-7def4b584569", "3aebb93c-ab03-47ac-aaee-5573387d304f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db260415-ee7f-4d7f-92c1-5ccf79b5ada8", "eab07ea1-a39e-4218-8aa8-5563c6ada2e5", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainantLocations_AddressId",
                table: "ComplainantLocations",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintLocations_AddressId",
                table: "ComplaintLocations",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainantLocations");

            migrationBuilder.DropTable(
                name: "ComplaintLocations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0972f9f-508d-4437-9dd4-7def4b584569");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db260415-ee7f-4d7f-92c1-5ccf79b5ada8");

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
    }
}
