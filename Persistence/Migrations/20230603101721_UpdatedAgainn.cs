using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedAgainn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Addresses_AddressId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_AddressId",
                table: "States");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e01dad2-e33f-4c4c-806a-843551354646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eff2099-feec-4776-8749-b2d543ca6f00");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "States");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80ea4138-f204-4a11-91e9-42fedcb3d8d4", "39a1c0bd-f8fb-4961-bf70-bf9264ba5190", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd7c39c5-fe67-4707-b778-4218d2560db3", "5edd615a-9083-4baf-b318-b8ce247137cf", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80ea4138-f204-4a11-91e9-42fedcb3d8d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd7c39c5-fe67-4707-b778-4218d2560db3");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "States",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e01dad2-e33f-4c4c-806a-843551354646", "ac108422-4c33-492c-933a-d71625a3a0cc", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eff2099-feec-4776-8749-b2d543ca6f00", "73b3c53d-991d-4533-a40b-92f7beaddbaa", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_States_AddressId",
                table: "States",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Addresses_AddressId",
                table: "States",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
