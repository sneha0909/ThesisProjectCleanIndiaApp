using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedCityAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80ea4138-f204-4a11-91e9-42fedcb3d8d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd7c39c5-fe67-4707-b778-4218d2560db3");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Cities");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "289a3d38-1a32-42ad-80f8-9c6d6f958153", "25a67ad1-9107-4d03-92ba-faf89dde4e2c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b51def1e-4d96-4052-b48f-bd87f6fe47fb", "df67356f-adc6-4697-bf0f-cba59d491bf7", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289a3d38-1a32-42ad-80f8-9c6d6f958153");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b51def1e-4d96-4052-b48f-bd87f6fe47fb");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Cities",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80ea4138-f204-4a11-91e9-42fedcb3d8d4", "39a1c0bd-f8fb-4961-bf70-bf9264ba5190", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd7c39c5-fe67-4707-b778-4218d2560db3", "5edd615a-9083-4baf-b318-b8ce247137cf", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId",
                unique: true);
        }
    }
}
