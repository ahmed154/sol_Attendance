using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class AlterColEmployeesWorksysId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departs_DepartId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Devices_DeviceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Secs_SecId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SecId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departs_DepartId",
                table: "Employees",
                column: "DepartId",
                principalTable: "Departs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Devices_DeviceId",
                table: "Employees",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Secs_SecId",
                table: "Employees",
                column: "SecId",
                principalTable: "Secs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departs_DepartId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Devices_DeviceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Secs_SecId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SecId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departs_DepartId",
                table: "Employees",
                column: "DepartId",
                principalTable: "Departs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Devices_DeviceId",
                table: "Employees",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Secs_SecId",
                table: "Employees",
                column: "SecId",
                principalTable: "Secs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
