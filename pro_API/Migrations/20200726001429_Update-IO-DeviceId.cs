using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class UpdateIODeviceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "IOs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "IOEdits",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "IOs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "IOEdits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
