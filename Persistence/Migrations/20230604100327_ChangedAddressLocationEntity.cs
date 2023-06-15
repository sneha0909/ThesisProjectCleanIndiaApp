using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class ChangedAddressLocationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0972f9f-508d-4437-9dd4-7def4b584569");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db260415-ee7f-4d7f-92c1-5ccf79b5ada8");

            migrationBuilder.RenameColumn(
                name: "ComplaintWardNo",
                table: "ComplaintLocations",
                newName: "ComplaintLocationWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantWardNo",
                table: "ComplainantLocations",
                newName: "ComplainantLocationWardNo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "938c7928-ddfa-4d89-b3b2-8608a3c601bc", "d1458ce1-954f-43c7-9748-12763d87a1eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5f0a6f2-b135-4b93-867e-f2e009f3687c", "40398821-a382-4e6c-b9a6-4fd0ec6fd183", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938c7928-ddfa-4d89-b3b2-8608a3c601bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f0a6f2-b135-4b93-867e-f2e009f3687c");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationWardNo",
                table: "ComplaintLocations",
                newName: "ComplaintWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantLocationWardNo",
                table: "ComplainantLocations",
                newName: "ComplainantWardNo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0972f9f-508d-4437-9dd4-7def4b584569", "3aebb93c-ab03-47ac-aaee-5573387d304f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db260415-ee7f-4d7f-92c1-5ccf79b5ada8", "eab07ea1-a39e-4218-8aa8-5563c6ada2e5", "Member", "MEMBER" });
        }
    }
}
