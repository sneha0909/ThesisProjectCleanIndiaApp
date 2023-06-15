using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemovedCircularReferenceIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fc0d97e-e08e-4b54-be1c-09fa2b925501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ffd66e3-a03b-4187-9a7b-3809785c5009");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c0e39a7-344d-4001-99f3-752c13000090", "f78081fc-9706-4932-907d-91749a2814b5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dda78bbc-885d-4bfe-b6bf-0efb06ee3d05", "bf9f98f6-31a3-435f-ac10-5c42b2e3e945", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0e39a7-344d-4001-99f3-752c13000090");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda78bbc-885d-4bfe-b6bf-0efb06ee3d05");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fc0d97e-e08e-4b54-be1c-09fa2b925501", "92e6f80b-b710-41fa-9a79-022425fb8085", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ffd66e3-a03b-4187-9a7b-3809785c5009", "2b4874f8-cbf8-4d46-afd3-517be02d0ece", "Admin", "ADMIN" });
        }
    }
}
