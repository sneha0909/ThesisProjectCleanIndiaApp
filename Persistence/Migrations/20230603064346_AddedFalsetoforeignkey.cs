using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedFalsetoforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f7d47c-cba8-4cb6-b524-57090e814daa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb64024f-d842-4bcd-8dbf-da80a9ed6e06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "380e17e7-7941-4c6c-9d77-9c2714ea3dba", "32c92ec1-53ae-4def-bca9-45514af4af68", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78b04be2-4502-481a-9f41-d5c94d6521ab", "c44feb59-5795-4e32-9c9b-b158577f1b98", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints",
                column: "Id",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "380e17e7-7941-4c6c-9d77-9c2714ea3dba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b04be2-4502-481a-9f41-d5c94d6521ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02f7d47c-cba8-4cb6-b524-57090e814daa", "9f823cc6-81f0-40b7-ac73-312d396becc0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb64024f-d842-4bcd-8dbf-da80a9ed6e06", "69ef6ee2-a3c3-4226-9316-50034be841a6", "Member", "MEMBER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Feedbacks_Id",
                table: "Complaints",
                column: "Id",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
