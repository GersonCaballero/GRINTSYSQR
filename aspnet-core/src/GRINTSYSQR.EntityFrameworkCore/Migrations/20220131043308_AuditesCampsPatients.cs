using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GRINTSYSQR.Migrations
{
    public partial class AuditesCampsPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Patients",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Patients",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Patients",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Patients");
        }
    }
}
