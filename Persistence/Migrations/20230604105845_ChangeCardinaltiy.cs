using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangeCardinaltiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTranslations_TranslatedComplaints_Id",
                table: "AddressTranslations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c105b3-d454-4d43-8c38-183dfca1fcea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecaf403a-6c77-472a-870f-e32e60999f8f");

            migrationBuilder.AddColumn<Guid>(
                name: "TranslatedComplaintId",
                table: "AddressTranslations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22a3a958-a069-485e-aee9-fcf02e478198", "c4964b15-80ad-42bf-a530-a332a34e1120", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78084b32-a141-40a5-9da7-9f288d254ef5", "a0572271-799d-40b2-944b-f23ad2e8a470", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTranslations_TranslatedComplaintId",
                table: "AddressTranslations",
                column: "TranslatedComplaintId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTranslations_TranslatedComplaints_TranslatedComplaintId",
                table: "AddressTranslations",
                column: "TranslatedComplaintId",
                principalTable: "TranslatedComplaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTranslations_TranslatedComplaints_TranslatedComplaintId",
                table: "AddressTranslations");

            migrationBuilder.DropIndex(
                name: "IX_AddressTranslations_TranslatedComplaintId",
                table: "AddressTranslations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a3a958-a069-485e-aee9-fcf02e478198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78084b32-a141-40a5-9da7-9f288d254ef5");

            migrationBuilder.DropColumn(
                name: "TranslatedComplaintId",
                table: "AddressTranslations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26c105b3-d454-4d43-8c38-183dfca1fcea", "4b941292-c712-4ced-a3ce-36fcb57d46bb", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecaf403a-6c77-472a-870f-e32e60999f8f", "ab70e38f-3cc0-4890-b5a8-7928f0be5d07", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTranslations_TranslatedComplaints_Id",
                table: "AddressTranslations",
                column: "Id",
                principalTable: "TranslatedComplaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
