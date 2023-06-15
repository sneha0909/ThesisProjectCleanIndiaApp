using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedStateAdresAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

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
                values: new object[] { "6e01dad2-e33f-4c4c-806a-843551354646", "ac108422-4c33-492c-933a-d71625a3a0cc", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eff2099-feec-4776-8749-b2d543ca6f00", "73b3c53d-991d-4533-a40b-92f7beaddbaa", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_States_AddressId",
                table: "States",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Addresses_AddressId",
                table: "States",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Addresses_AddressId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_AddressId",
                table: "States");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e01dad2-e33f-4c4c-806a-843551354646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eff2099-feec-4776-8749-b2d543ca6f00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29486bb1-f7bf-4479-b3ce-dad2ed108545", "8bf29f65-6731-4154-961d-5d15445cd3aa", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f695fca-e759-4da9-9dda-cf4cb4229b61", "fadfebc7-b5dd-49d5-89bc-b23549cf6f71", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
