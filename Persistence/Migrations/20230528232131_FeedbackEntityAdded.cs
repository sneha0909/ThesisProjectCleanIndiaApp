using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class FeedbackEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e6e2751-2229-490f-9ac9-e6ed6b36e538");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a937815-ae1f-4519-9397-8e7ec931a94b");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Complaints");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2df5d2fc-3f67-46bd-828f-09f1d0777b00", "d03cc690-36fc-4cc6-b918-cf588edbeb52", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd8baeb3-b27e-4427-b0f2-c4236a9edf6c", "507f78ab-b652-417c-8a75-e04522abe819", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ComplaintId",
                table: "Feedbacks",
                column: "ComplaintId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2df5d2fc-3f67-46bd-828f-09f1d0777b00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd8baeb3-b27e-4427-b0f2-c4236a9edf6c");

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e6e2751-2229-490f-9ac9-e6ed6b36e538", "77dbf6f3-8387-4fe8-bedf-3395a83dd84b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a937815-ae1f-4519-9397-8e7ec931a94b", "5b1c2c11-95fe-46fe-8162-dd6691e61965", "Member", "MEMBER" });
        }
    }
}
