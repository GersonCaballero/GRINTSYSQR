using Microsoft.EntityFrameworkCore.Migrations;

namespace GRINTSYSQR.Migrations
{
    public partial class AddNewCampsForTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLogo",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressStamp",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLogo",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "AddressStamp",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AbpTenants");
        }
    }
}
