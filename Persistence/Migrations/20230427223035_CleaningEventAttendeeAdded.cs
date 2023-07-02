using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CleaningEventAttendeeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bb3133d-e208-4d45-baaf-bba9f60f6eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36758a37-6a15-40f2-b815-53181f31aaa4");

            migrationBuilder.CreateTable(
                name: "CleaningEventAttendees",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    CleaningEventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsHost = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningEventAttendees", x => new { x.AppUserId, x.CleaningEventId });
                    table.ForeignKey(
                        name: "FK_CleaningEventAttendees_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleaningEventAttendees_CleaningEvents_CleaningEventId",
                        column: x => x.CleaningEventId,
                        principalTable: "CleaningEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2432cad9-7ec2-45a6-874b-dbf8552b061f", "9670d34d-3e7b-4748-b691-0e963178d19a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9261c2dd-5c1a-452f-b86d-77df45b4b2bf", "6d02c711-1f02-43a8-9202-67e900d15c81", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningEventAttendees_CleaningEventId",
                table: "CleaningEventAttendees",
                column: "CleaningEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningEventAttendees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2432cad9-7ec2-45a6-874b-dbf8552b061f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9261c2dd-5c1a-452f-b86d-77df45b4b2bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bb3133d-e208-4d45-baaf-bba9f60f6eb9", "31259460-e8e5-49f1-8c71-cdcc9d80ffa9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36758a37-6a15-40f2-b815-53181f31aaa4", "e26564c6-9e04-408a-82d4-29da85a469ed", "Admin", "ADMIN" });
        }
    }
}
