using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ComplaintFeedbackAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6fe7613-5693-48a1-bca0-6477e0909ade");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d104e6c7-6bd9-4427-b990-5ddb0578d0cc");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6fe7613-5693-48a1-bca0-6477e0909ade", "fcd2ffcf-c7a6-4b50-bcb8-4bd6be43af33", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d104e6c7-6bd9-4427-b990-5ddb0578d0cc", "93a43f98-159c-48af-808c-9eee97d6140b", "Admin", "ADMIN" });
        }
    }
}
