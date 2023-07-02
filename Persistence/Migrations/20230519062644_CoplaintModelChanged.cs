using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CoplaintModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c810d6d1-7ea1-44ae-93db-f7166e8557be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e07a8dd4-ba9d-46e5-a470-8f90efcba947");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressArea1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressArea2",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressAreaInAddress",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressCity",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressCountry",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressHouseName",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressHouseNo",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressLandmark",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplainantAddressOfficeTelephone",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "CleaningEventAttendees");

            migrationBuilder.RenameColumn(
                name: "DescriptionofComplaint",
                table: "Complaints",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationHouseName",
                table: "Complaints",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ComplaintLocationArea2",
                table: "Complaints",
                newName: "ComplainantZoneWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressZoneWardNo",
                table: "Complaints",
                newName: "ComplainantWard");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressWard",
                table: "Complaints",
                newName: "ComplainantState");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressState",
                table: "Complaints",
                newName: "ComplainantLandmark");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressSTDCodeResidenceTelephone",
                table: "Complaints",
                newName: "ComplainantHouseNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressSTDCodeOfficeTelephone",
                table: "Complaints",
                newName: "ComplainantCity");

            migrationBuilder.RenameColumn(
                name: "ComplainantAddressResidenceTelephone",
                table: "Complaints",
                newName: "ComplainantArea");

            migrationBuilder.AlterColumn<int>(
                name: "ComplaintType",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComplaintSubType",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComplaintStatus",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Complaints",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac2863ff-1f3e-4e8f-8b54-ec1253aa0252", "e278e0d7-2ba7-4283-a2ee-945bb48d0faa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e51766a4-67c5-4151-9725-51a5c6d294fe", "4eef272e-70be-4443-bbc8-9d2d80e41352", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2863ff-1f3e-4e8f-8b54-ec1253aa0252");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e51766a4-67c5-4151-9725-51a5c6d294fe");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Complaints",
                newName: "DescriptionofComplaint");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Complaints",
                newName: "ComplaintLocationHouseName");

            migrationBuilder.RenameColumn(
                name: "ComplainantZoneWardNo",
                table: "Complaints",
                newName: "ComplaintLocationArea2");

            migrationBuilder.RenameColumn(
                name: "ComplainantWard",
                table: "Complaints",
                newName: "ComplainantAddressZoneWardNo");

            migrationBuilder.RenameColumn(
                name: "ComplainantState",
                table: "Complaints",
                newName: "ComplainantAddressWard");

            migrationBuilder.RenameColumn(
                name: "ComplainantLandmark",
                table: "Complaints",
                newName: "ComplainantAddressState");

            migrationBuilder.RenameColumn(
                name: "ComplainantHouseNo",
                table: "Complaints",
                newName: "ComplainantAddressSTDCodeResidenceTelephone");

            migrationBuilder.RenameColumn(
                name: "ComplainantCity",
                table: "Complaints",
                newName: "ComplainantAddressSTDCodeOfficeTelephone");

            migrationBuilder.RenameColumn(
                name: "ComplainantArea",
                table: "Complaints",
                newName: "ComplainantAddressResidenceTelephone");

            migrationBuilder.AlterColumn<string>(
                name: "ComplaintType",
                table: "Complaints",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ComplaintSubType",
                table: "Complaints",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ComplaintStatus",
                table: "Complaints",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressArea1",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressArea2",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressAreaInAddress",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressCity",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressCountry",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressHouseName",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressHouseNo",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressLandmark",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplainantAddressOfficeTelephone",
                table: "Complaints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LanguageCode",
                table: "CleaningEventAttendees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c810d6d1-7ea1-44ae-93db-f7166e8557be", "27e4a4b0-366d-41c4-a6a2-762f93310332", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e07a8dd4-ba9d-46e5-a470-8f90efcba947", "9c3bf951-79e9-4c66-9de1-224e48693c0e", "Member", "MEMBER" });
        }
    }
}
