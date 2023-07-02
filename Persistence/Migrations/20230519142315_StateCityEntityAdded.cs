using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class StateCityEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2863ff-1f3e-4e8f-8b54-ec1253aa0252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e51766a4-67c5-4151-9725-51a5c6d294fe");

            migrationBuilder.DropColumn(
                name: "ComplainantCity",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantState",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLocationCity",
                table: "Complaints");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StateName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CityName = table.Column<string>(type: "TEXT", nullable: true),
                    StateId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e1f54fe-67a7-45a8-8146-5b6d4a6f3cb8", "1ac3d177-0306-43da-8b7e-a4f8d9acdb63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ac9947f-fc9a-4282-8402-bd4a25c1582e", "5bf393f0-dcc4-4c8a-be2e-de1cbb217a59", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CityId",
                table: "Complaints",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_StateId",
                table: "Complaints",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Cities_CityId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_States_StateId",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_CityId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_StateId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1f54fe-67a7-45a8-8146-5b6d4a6f3cb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac9947f-fc9a-4282-8402-bd4a25c1582e");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "ComplainantCity",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantState",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintLocationCity",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac2863ff-1f3e-4e8f-8b54-ec1253aa0252", "e278e0d7-2ba7-4283-a2ee-945bb48d0faa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e51766a4-67c5-4151-9725-51a5c6d294fe", "4eef272e-70be-4443-bbc8-9d2d80e41352", "Member", "MEMBER" });
        }
    }
}
