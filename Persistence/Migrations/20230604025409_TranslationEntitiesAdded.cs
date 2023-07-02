using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class TranslationEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaints");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId",
                table: "TranslatedComplaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslatedComplaints",
                table: "TranslatedComplaints");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedComplaints_ComplaintId",
                table: "TranslatedComplaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289a3d38-1a32-42ad-80f8-9c6d6f958153");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b51def1e-4d96-4052-b48f-bd87f6fe47fb");

            migrationBuilder.RenameTable(
                name: "TranslatedComplaints",
                newName: "TranslatedComplaintsHindi");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaints_AddressTranslationId",
                table: "TranslatedComplaintsHindi",
                newName: "IX_TranslatedComplaintsHindi_AddressTranslationId");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintId1",
                table: "TranslatedComplaintsHindi",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "TranslatedComplaintsHindi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslatedComplaintsHindi",
                table: "TranslatedComplaintsHindi",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33e3b333-701a-4e27-be8b-36f4cdede325", "0eb3dba6-6371-44d0-8c7f-3d47151cc4c5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41d738ea-5ce2-4916-bc9d-9fe2aa8cf025", "8e575872-30d8-4273-bac8-dab5a0d8f318", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId",
                table: "TranslatedComplaintsHindi",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId1",
                table: "TranslatedComplaintsHindi",
                column: "ComplaintId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaintsHindi_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaintsHindi",
                column: "AddressTranslationId",
                principalTable: "AddressTranslation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaintsHindi_Complaints_ComplaintId",
                table: "TranslatedComplaintsHindi",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaintsHindi_Complaints_ComplaintId1",
                table: "TranslatedComplaintsHindi",
                column: "ComplaintId1",
                principalTable: "Complaints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaintsHindi_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaintsHindi_Complaints_ComplaintId",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaintsHindi_Complaints_ComplaintId1",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslatedComplaintsHindi",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId1",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e3b333-701a-4e27-be8b-36f4cdede325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d738ea-5ce2-4916-bc9d-9fe2aa8cf025");

            migrationBuilder.DropColumn(
                name: "ComplaintId1",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TranslatedComplaintsHindi");

            migrationBuilder.RenameTable(
                name: "TranslatedComplaintsHindi",
                newName: "TranslatedComplaints");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaintsHindi_AddressTranslationId",
                table: "TranslatedComplaints",
                newName: "IX_TranslatedComplaints_AddressTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslatedComplaints",
                table: "TranslatedComplaints",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "289a3d38-1a32-42ad-80f8-9c6d6f958153", "25a67ad1-9107-4d03-92ba-faf89dde4e2c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b51def1e-4d96-4052-b48f-bd87f6fe47fb", "df67356f-adc6-4697-bf0f-cba59d491bf7", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaints_ComplaintId",
                table: "TranslatedComplaints",
                column: "ComplaintId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaints",
                column: "AddressTranslationId",
                principalTable: "AddressTranslation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId",
                table: "TranslatedComplaints",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
