using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class NewEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Cities_CityId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_States_StateId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_CityId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2df5d2fc-3f67-46bd-828f-09f1d0777b00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd8baeb3-b27e-4427-b0f2-c4236a9edf6c");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantArea",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantHouseNo",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantLandmark",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantWardNo",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationArea",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationPincode",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationWardNo",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Complaints",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_StateId",
                table: "Complaints",
                newName: "IX_Complaints_AddressId");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "States",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Cities",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pincode = table.Column<string>(type: "TEXT", nullable: true),
                    StateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TranslatedComplaintLocationArea = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatedComplaintLocationLandmark = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatedComplainantLocationHouseName = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatedComplainantLocationLandmark = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatedComplainantLocationArea = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTranslation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslatedComplaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TranslatedDescription = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatedComplainantName = table.Column<string>(type: "TEXT", nullable: true),
                    AddressTranslationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FeedbackMessage = table.Column<string>(type: "TEXT", nullable: true),
                    ComplaintId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatedComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslatedComplaints_AddressTranslation_AddressTranslationId",
                        column: x => x.AddressTranslationId,
                        principalTable: "AddressTranslation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranslatedComplaints_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d761570-86e8-42e4-9ba8-d99d3bc1af1c", "402764e7-43cb-482a-a3b6-16fe520ef762", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93af60a6-b9f1-4a3a-b9f0-a7851cc5c70c", "9557aab3-f573-4e93-8f2d-8ac7d7ebaa39", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaints_AddressTranslationId",
                table: "TranslatedComplaints",
                column: "AddressTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedComplaints_ComplaintId",
                table: "TranslatedComplaints",
                column: "ComplaintId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Addresses_AddressId",
                table: "Complaints",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Addresses_AddressId",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "TranslatedComplaints");

            migrationBuilder.DropTable(
                name: "AddressTranslation");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d761570-86e8-42e4-9ba8-d99d3bc1af1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93af60a6-b9f1-4a3a-b9f0-a7851cc5c70c");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Complaints",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_AddressId",
                table: "Complaints",
                newName: "IX_Complaints_StateId");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ComplainantArea",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantHouseNo",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantLandmark",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantWardNo",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationArea",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationPincode",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationWardNo",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2df5d2fc-3f67-46bd-828f-09f1d0777b00", "d03cc690-36fc-4cc6-b918-cf588edbeb52", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd8baeb3-b27e-4427-b0f2-c4236a9edf6c", "507f78ab-b652-417c-8a75-e04522abe819", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CityId",
                table: "Complaints",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Cities_CityId",
                table: "Complaints",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_States_StateId",
                table: "Complaints",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
