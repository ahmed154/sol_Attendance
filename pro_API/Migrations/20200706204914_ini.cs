using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSyss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Day_Hours = table.Column<int>(nullable: false),
                    Day_Min = table.Column<int>(nullable: false),
                    ti = table.Column<bool>(nullable: false),
                    First_as = table.Column<decimal>(nullable: false),
                    First_ae = table.Column<decimal>(nullable: false),
                    First_ls = table.Column<decimal>(nullable: false),
                    First_le = table.Column<decimal>(nullable: false),
                    Second_as = table.Column<decimal>(nullable: false),
                    Second_ae = table.Column<decimal>(nullable: false),
                    Second_ls = table.Column<decimal>(nullable: false),
                    Second_le = table.Column<decimal>(nullable: false),
                    saPeriod_Hours = table.Column<string>(nullable: true),
                    saType = table.Column<bool>(nullable: false),
                    sah = table.Column<bool>(nullable: false),
                    saBonus = table.Column<bool>(nullable: false),
                    saf = table.Column<bool>(nullable: false),
                    safs = table.Column<DateTime>(nullable: false),
                    safe = table.Column<DateTime>(nullable: false),
                    safa = table.Column<DateTime>(nullable: false),
                    sas = table.Column<bool>(nullable: false),
                    sass = table.Column<DateTime>(nullable: false),
                    sase = table.Column<DateTime>(nullable: false),
                    sasa = table.Column<DateTime>(nullable: false),
                    suPeriod_Hours = table.Column<string>(nullable: true),
                    suType = table.Column<bool>(nullable: false),
                    suh = table.Column<bool>(nullable: false),
                    suBonus = table.Column<bool>(nullable: false),
                    suf = table.Column<bool>(nullable: false),
                    sufs = table.Column<DateTime>(nullable: false),
                    sufe = table.Column<DateTime>(nullable: false),
                    sufa = table.Column<DateTime>(nullable: false),
                    sus = table.Column<bool>(nullable: false),
                    suss = table.Column<DateTime>(nullable: false),
                    suse = table.Column<DateTime>(nullable: false),
                    susa = table.Column<DateTime>(nullable: false),
                    moPeriod_Hours = table.Column<string>(nullable: true),
                    moType = table.Column<bool>(nullable: false),
                    moh = table.Column<bool>(nullable: false),
                    moBonus = table.Column<bool>(nullable: false),
                    mof = table.Column<bool>(nullable: false),
                    mofs = table.Column<DateTime>(nullable: false),
                    mofe = table.Column<DateTime>(nullable: false),
                    mofa = table.Column<DateTime>(nullable: false),
                    mos = table.Column<bool>(nullable: false),
                    moss = table.Column<DateTime>(nullable: false),
                    mose = table.Column<DateTime>(nullable: false),
                    mosa = table.Column<DateTime>(nullable: false),
                    tuPeriod_Hours = table.Column<string>(nullable: true),
                    tuType = table.Column<bool>(nullable: false),
                    tuh = table.Column<bool>(nullable: false),
                    tuBonus = table.Column<bool>(nullable: false),
                    tuf = table.Column<bool>(nullable: false),
                    tufs = table.Column<DateTime>(nullable: false),
                    tufe = table.Column<DateTime>(nullable: false),
                    tufa = table.Column<DateTime>(nullable: false),
                    tus = table.Column<bool>(nullable: false),
                    tuss = table.Column<DateTime>(nullable: false),
                    tuse = table.Column<DateTime>(nullable: false),
                    tusa = table.Column<DateTime>(nullable: false),
                    wePeriod_Hours = table.Column<string>(nullable: true),
                    weType = table.Column<bool>(nullable: false),
                    weh = table.Column<bool>(nullable: false),
                    weBonus = table.Column<bool>(nullable: false),
                    wef = table.Column<bool>(nullable: false),
                    wefs = table.Column<DateTime>(nullable: false),
                    wefe = table.Column<DateTime>(nullable: false),
                    wefa = table.Column<DateTime>(nullable: false),
                    wes = table.Column<bool>(nullable: false),
                    wess = table.Column<DateTime>(nullable: false),
                    wese = table.Column<DateTime>(nullable: false),
                    wesa = table.Column<DateTime>(nullable: false),
                    thPeriod_Hours = table.Column<string>(nullable: true),
                    thType = table.Column<bool>(nullable: false),
                    thh = table.Column<bool>(nullable: false),
                    thBonus = table.Column<bool>(nullable: false),
                    thf = table.Column<bool>(nullable: false),
                    thfs = table.Column<DateTime>(nullable: false),
                    thfe = table.Column<DateTime>(nullable: false),
                    thfa = table.Column<DateTime>(nullable: false),
                    ths = table.Column<bool>(nullable: false),
                    thss = table.Column<DateTime>(nullable: false),
                    thse = table.Column<DateTime>(nullable: false),
                    thsa = table.Column<DateTime>(nullable: false),
                    frPeriod_Hours = table.Column<string>(nullable: true),
                    frType = table.Column<bool>(nullable: false),
                    frh = table.Column<bool>(nullable: false),
                    frBonus = table.Column<bool>(nullable: false),
                    frf = table.Column<bool>(nullable: false),
                    frfs = table.Column<DateTime>(nullable: false),
                    frfe = table.Column<DateTime>(nullable: false),
                    frfa = table.Column<DateTime>(nullable: false),
                    frs = table.Column<bool>(nullable: false),
                    frss = table.Column<DateTime>(nullable: false),
                    frse = table.Column<DateTime>(nullable: false),
                    rfsa = table.Column<DateTime>(nullable: false),
                    BonusCheck = table.Column<bool>(nullable: false),
                    LateCheck = table.Column<bool>(nullable: false),
                    AttEarly = table.Column<bool>(nullable: false),
                    LeaveEarly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSyss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DeviceId = table.Column<string>(nullable: true),
                    WSId = table.Column<int>(nullable: false),
                    Departd = table.Column<int>(nullable: false),
                    SecId = table.Column<int>(nullable: false),
                    DeviceId1 = table.Column<int>(nullable: true),
                    WorkSysId = table.Column<int>(nullable: true),
                    DepartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emps_Departs_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Departs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emps_Devices_DeviceId1",
                        column: x => x.DeviceId1,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emps_Secs_SecId",
                        column: x => x.SecId,
                        principalTable: "Secs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emps_WorkSyss_WorkSysId",
                        column: x => x.WorkSysId,
                        principalTable: "WorkSyss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IOEdits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(nullable: true),
                    TTime = table.Column<DateTime>(nullable: false),
                    Event = table.Column<int>(nullable: false),
                    EmpId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<string>(nullable: true),
                    EditTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DeviceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOEdits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOEdits_Devices_DeviceId1",
                        column: x => x.DeviceId1,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IOEdits_Emps_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(nullable: false),
                    TTime = table.Column<DateTime>(nullable: false),
                    Event = table.Column<int>(nullable: false),
                    EmpId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<string>(nullable: false),
                    Priority = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeviceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOs_Devices_DeviceId1",
                        column: x => x.DeviceId1,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IOs_Emps_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emps_DepartId",
                table: "Emps",
                column: "DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Emps_DeviceId1",
                table: "Emps",
                column: "DeviceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Emps_SecId",
                table: "Emps",
                column: "SecId");

            migrationBuilder.CreateIndex(
                name: "IX_Emps_WorkSysId",
                table: "Emps",
                column: "WorkSysId");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_DeviceId1",
                table: "IOEdits",
                column: "DeviceId1");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_EmpId",
                table: "IOEdits",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_DeviceId1",
                table: "IOs",
                column: "DeviceId1");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_EmpId",
                table: "IOs",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOEdits");

            migrationBuilder.DropTable(
                name: "IOs");

            migrationBuilder.DropTable(
                name: "Emps");

            migrationBuilder.DropTable(
                name: "Departs");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Secs");

            migrationBuilder.DropTable(
                name: "WorkSyss");
        }
    }
}
