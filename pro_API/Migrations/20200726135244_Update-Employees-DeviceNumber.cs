using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class UpdateEmployeesDeviceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "IOs");

            migrationBuilder.AddColumn<string>(
                name: "DeviceNumber",
                table: "IOs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceNumber",
                table: "IOs");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "IOs",
                type: "int",
                nullable: true);
        }
    }
}
