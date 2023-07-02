using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class PublicIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71af6cd1-abde-434f-8903-787c48e64ddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3f0d336-fbda-43d5-b5c7-71548f0e744f");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dad8da2d-ee9e-49f9-9c29-964ecd04c9e6", "e552304b-1fb9-4d57-9596-8f575a6c14fe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f933ed0f-322b-4570-80cf-8a213a2c7beb", "0081369c-4b83-407a-ac5b-a41c9418a388", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad8da2d-ee9e-49f9-9c29-964ecd04c9e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f933ed0f-322b-4570-80cf-8a213a2c7beb");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Complaints");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71af6cd1-abde-434f-8903-787c48e64ddc", "12440688-74f1-4b9c-a18d-383c58a2aec2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3f0d336-fbda-43d5-b5c7-71548f0e744f", "9ce29462-120f-4475-8e55-5b8a4a799a9d", "Member", "MEMBER" });
        }
    }
}
