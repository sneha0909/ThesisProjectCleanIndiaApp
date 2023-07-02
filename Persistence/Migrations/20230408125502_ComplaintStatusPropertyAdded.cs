using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ComplaintStatusPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad8da2d-ee9e-49f9-9c29-964ecd04c9e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f933ed0f-322b-4570-80cf-8a213a2c7beb");

            migrationBuilder.AddColumn<string>(
                name: "ComplaintStatus",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cb059e8-04a6-488a-bf86-1661ae54e9ca", "a92666c1-a803-4fa4-86fc-e01102174780", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8d39bd0-2a90-43b8-8b1b-782a6a15320d", "ed7168bb-0c33-438b-b733-645bbd2365c0", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cb059e8-04a6-488a-bf86-1661ae54e9ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8d39bd0-2a90-43b8-8b1b-782a6a15320d");

            migrationBuilder.DropColumn(
                name: "ComplaintStatus",
                table: "Complaints");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dad8da2d-ee9e-49f9-9c29-964ecd04c9e6", "e552304b-1fb9-4d57-9596-8f575a6c14fe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f933ed0f-322b-4570-80cf-8a213a2c7beb", "0081369c-4b83-407a-ac5b-a41c9418a388", "Member", "MEMBER" });
        }
    }
}
