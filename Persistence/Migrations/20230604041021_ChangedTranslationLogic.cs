using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedTranslationLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057454b3-023a-4749-80ad-a43cfde2862c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b6f67d6-4ab3-4113-aea5-840aae4eb065");

            migrationBuilder.RenameTable(
                name: "TranslatedComplaintsHindi",
                newName: "TranslatedComplaints");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId1",
                table: "TranslatedComplaints",
                newName: "IX_TranslatedComplaints_ComplaintId1");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaintsHindi_ComplaintId",
                table: "TranslatedComplaints",
                newName: "IX_TranslatedComplaints_ComplaintId");

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
                values: new object[] { "aa9eff29-dbaf-42bd-aac9-d5f6cacc394c", "18638bad-c734-455d-8dee-08725e51e764", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5c95062-d275-414c-9d83-21d01bda0c61", "5970aa70-7d9b-4454-b795-454020c8a4df", "Admin", "ADMIN" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId1",
                table: "TranslatedComplaints",
                column: "ComplaintId1",
                principalTable: "Complaints",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                table: "TranslatedComplaints");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId",
                table: "TranslatedComplaints");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedComplaints_Complaints_ComplaintId1",
                table: "TranslatedComplaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranslatedComplaints",
                table: "TranslatedComplaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa9eff29-dbaf-42bd-aac9-d5f6cacc394c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5c95062-d275-414c-9d83-21d01bda0c61");

            migrationBuilder.RenameTable(
                name: "TranslatedComplaints",
                newName: "TranslatedComplaintsHindi");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaints_ComplaintId1",
                table: "TranslatedComplaintsHindi",
                newName: "IX_TranslatedComplaintsHindi_ComplaintId1");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaints_ComplaintId",
                table: "TranslatedComplaintsHindi",
                newName: "IX_TranslatedComplaintsHindi_ComplaintId");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatedComplaints_AddressTranslationId",
                table: "TranslatedComplaintsHindi",
                newName: "IX_TranslatedComplaintsHindi_AddressTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranslatedComplaintsHindi",
                table: "TranslatedComplaintsHindi",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "057454b3-023a-4749-80ad-a43cfde2862c", "ac09b72f-ff14-49b4-b462-70651821ee00", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b6f67d6-4ab3-4113-aea5-840aae4eb065", "ef413459-b52b-4303-81e1-cb4714dc7f18", "Admin", "ADMIN" });

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
    }
}
