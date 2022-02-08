using Microsoft.EntityFrameworkCore.Migrations;

namespace GRINTSYSQR.Migrations
{
    public partial class AddRTNForTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RTN",
                table: "AbpTenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RTN",
                table: "AbpTenants");
        }
    }
}
