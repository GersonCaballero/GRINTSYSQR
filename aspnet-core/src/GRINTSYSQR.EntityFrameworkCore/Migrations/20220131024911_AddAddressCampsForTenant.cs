using Microsoft.EntityFrameworkCore.Migrations;

namespace GRINTSYSQR.Migrations
{
    public partial class AddAddressCampsForTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrincipalAddress",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAddress",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipalAddress",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "SecondaryAddress",
                table: "AbpTenants");
        }
    }
}
