using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class UpdateIOEmpIdDeviceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_IOEdits_Employees_EmpId",
                table: "IOEdits");

            migrationBuilder.DropForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs");

            migrationBuilder.DropForeignKey(
                name: "FK_IOs_Employees_EmpId",
                table: "IOs");

            migrationBuilder.DropIndex(
                name: "IX_IOs_DeviceId",
                table: "IOs");

            migrationBuilder.DropIndex(
                name: "IX_IOs_EmpId",
                table: "IOs");

            migrationBuilder.DropIndex(
                name: "IX_IOEdits_DeviceId",
                table: "IOEdits");

            migrationBuilder.DropIndex(
                name: "IX_IOEdits_EmpId",
                table: "IOEdits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IOs_DeviceId",
                table: "IOs",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_EmpId",
                table: "IOs",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_DeviceId",
                table: "IOEdits",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_EmpId",
                table: "IOEdits",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IOEdits_Devices_DeviceId",
                table: "IOEdits",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IOEdits_Employees_EmpId",
                table: "IOEdits",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IOs_Devices_DeviceId",
                table: "IOs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IOs_Employees_EmpId",
                table: "IOs",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
