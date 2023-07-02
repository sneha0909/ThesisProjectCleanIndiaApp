using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class TypesAdSubtypesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08b124d5-a3bc-49eb-bbef-371cc47feecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fd6177-6ec7-4fc1-80bb-9ab935e155aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5693f4f-fee5-4d5f-b347-77fd33b93b4f", "d8ddfffc-9851-4185-be2b-11f08fe93797", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfa25ca5-f000-484b-ae40-eaaf214f1954", "c78fbe04-46a7-4d0c-aba5-31123b57db98", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5693f4f-fee5-4d5f-b347-77fd33b93b4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfa25ca5-f000-484b-ae40-eaaf214f1954");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08b124d5-a3bc-49eb-bbef-371cc47feecb", "047ddda5-01c2-4a79-bddb-111e1a163ae2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5fd6177-6ec7-4fc1-80bb-9ab935e155aa", "604d8e6a-e989-4a97-a14a-27235da5e9ce", "Member", "MEMBER" });
        }
    }
}
