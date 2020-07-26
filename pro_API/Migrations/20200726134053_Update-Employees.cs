using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class UpdateEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "IOs");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "IOs");

            migrationBuilder.AddColumn<string>(
                name: "EmpNumber",
                table: "IOs",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpNumber",
                table: "IOs");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "IOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "IOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
