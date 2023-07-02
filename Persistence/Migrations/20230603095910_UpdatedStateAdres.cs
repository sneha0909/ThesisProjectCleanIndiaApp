using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedStateAdres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9fec076-50d9-441e-84c1-9f0c4b7d9610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3077135-5a13-4982-ad13-a4f4014ec732");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29486bb1-f7bf-4479-b3ce-dad2ed108545", "8bf29f65-6731-4154-961d-5d15445cd3aa", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f695fca-e759-4da9-9dda-cf4cb4229b61", "fadfebc7-b5dd-49d5-89bc-b23549cf6f71", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29486bb1-f7bf-4479-b3ce-dad2ed108545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f695fca-e759-4da9-9dda-cf4cb4229b61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9fec076-50d9-441e-84c1-9f0c4b7d9610", "0478d778-2dd2-4e69-8f1d-7759c47b009a", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3077135-5a13-4982-ad13-a4f4014ec732", "2f31c8bc-10c3-4224-962d-1832397d2438", "Admin", "ADMIN" });
        }
    }
}
