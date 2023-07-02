using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangeAddressrasaltion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaints");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedComplaints_AddressTranslationId",
                table: "TranslatedComplaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTranslation",
                table: "AddressTranslation");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938c7928-ddfa-4d89-b3b2-8608a3c601bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f0a6f2-b135-4b93-867e-f2e009f3687c");

            migrationBuilder.DropColumn(
                name: "AddressTranslationId",
                table: "TranslatedComplaints");

            migrationBuilder.RenameTable(
                name: "AddressTranslation",
                newName: "AddressTranslations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTranslations",
                table: "AddressTranslations",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTranslations_TranslatedComplaints_Id",
                table: "AddressTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTranslations",
                table: "AddressTranslations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c105b3-d454-4d43-8c38-183dfca1fcea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecaf403a-6c77-472a-870f-e32e60999f8f");

            migrationBuilder.RenameTable(
                name: "AddressTranslations",
                newName: "AddressTranslation");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressTranslationId",
                table: "TranslatedComplaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTranslation",
                table: "AddressTranslation",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "938c7928-ddfa-4d89-b3b2-8608a3c601bc", "d1458ce1-954f-43c7-9748-12763d87a1eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5f0a6f2-b135-4b93-867e-f2e009f3687c", "40398821-a382-4e6c-b9a6-4fd0ec6fd183", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaints_AddressTranslationId",
                table: "TranslatedComplaints",
                column: "AddressTranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaints",
                column: "AddressTranslationId",
                principalTable: "AddressTranslation",
                principalColumn: "Id");
        }
    }
}
