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
                name: "Worksyss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Day_Hours = table.Column<int>(nullable: false),
                    Day_Min = table.Column<int>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    ti = table.Column<bool>(nullable: false),
                    First_as = table.Column<decimal>(nullable: false),
                    First_ae = table.Column<decimal>(nullable: false),
                    First_ls = table.Column<decimal>(nullable: false),
                    First_le = table.Column<decimal>(nullable: false),
                    Second_as = table.Column<decimal>(nullable: false),
                    Second_ae = table.Column<decimal>(nullable: false),
                    Second_ls = table.Column<decimal>(nullable: false),
                    Second_le = table.Column<decimal>(nullable: false),
                    saPeriod_Hours = table.Column<DateTime>(nullable: true),
                    saType = table.Column<bool>(nullable: false),
                    sah = table.Column<bool>(nullable: false),
                    saBonus = table.Column<bool>(nullable: false),
                    saf = table.Column<bool>(nullable: false),
                    safs = table.Column<DateTime>(nullable: true),
                    safe = table.Column<DateTime>(nullable: true),
                    safa = table.Column<DateTime>(nullable: true),
                    sas = table.Column<bool>(nullable: false),
                    sass = table.Column<DateTime>(nullable: true),
                    sase = table.Column<DateTime>(nullable: true),
                    sasa = table.Column<DateTime>(nullable: true),
                    suPeriod_Hours = table.Column<DateTime>(nullable: true),
                    suType = table.Column<bool>(nullable: false),
                    suh = table.Column<bool>(nullable: false),
                    suBonus = table.Column<bool>(nullable: false),
                    suf = table.Column<bool>(nullable: false),
                    sufs = table.Column<DateTime>(nullable: true),
                    sufe = table.Column<DateTime>(nullable: true),
                    sufa = table.Column<DateTime>(nullable: true),
                    sus = table.Column<bool>(nullable: false),
                    suss = table.Column<DateTime>(nullable: true),
                    suse = table.Column<DateTime>(nullable: true),
                    susa = table.Column<DateTime>(nullable: true),
                    moPeriod_Hours = table.Column<DateTime>(nullable: true),
                    moType = table.Column<bool>(nullable: false),
                    moh = table.Column<bool>(nullable: false),
                    moBonus = table.Column<bool>(nullable: false),
                    mof = table.Column<bool>(nullable: false),
                    mofs = table.Column<DateTime>(nullable: true),
                    mofe = table.Column<DateTime>(nullable: true),
                    mofa = table.Column<DateTime>(nullable: true),
                    mos = table.Column<bool>(nullable: false),
                    moss = table.Column<DateTime>(nullable: true),
                    mose = table.Column<DateTime>(nullable: true),
                    mosa = table.Column<DateTime>(nullable: true),
                    tuPeriod_Hours = table.Column<DateTime>(nullable: true),
                    tuType = table.Column<bool>(nullable: false),
                    tuh = table.Column<bool>(nullable: false),
                    tuBonus = table.Column<bool>(nullable: false),
                    tuf = table.Column<bool>(nullable: false),
                    tufs = table.Column<DateTime>(nullable: true),
                    tufe = table.Column<DateTime>(nullable: true),
                    tufa = table.Column<DateTime>(nullable: true),
                    tus = table.Column<bool>(nullable: false),
                    tuss = table.Column<DateTime>(nullable: true),
                    tuse = table.Column<DateTime>(nullable: true),
                    tusa = table.Column<DateTime>(nullable: true),
                    wePeriod_Hours = table.Column<DateTime>(nullable: true),
                    weType = table.Column<bool>(nullable: false),
                    weh = table.Column<bool>(nullable: false),
                    weBonus = table.Column<bool>(nullable: false),
                    wef = table.Column<bool>(nullable: false),
                    wefs = table.Column<DateTime>(nullable: true),
                    wefe = table.Column<DateTime>(nullable: true),
                    wefa = table.Column<DateTime>(nullable: true),
                    wes = table.Column<bool>(nullable: false),
                    wess = table.Column<DateTime>(nullable: true),
                    wese = table.Column<DateTime>(nullable: true),
                    wesa = table.Column<DateTime>(nullable: true),
                    thPeriod_Hours = table.Column<DateTime>(nullable: true),
                    thType = table.Column<bool>(nullable: false),
                    thh = table.Column<bool>(nullable: false),
                    thBonus = table.Column<bool>(nullable: false),
                    thf = table.Column<bool>(nullable: false),
                    thfs = table.Column<DateTime>(nullable: true),
                    thfe = table.Column<DateTime>(nullable: true),
                    thfa = table.Column<DateTime>(nullable: true),
                    ths = table.Column<bool>(nullable: false),
                    thss = table.Column<DateTime>(nullable: true),
                    thse = table.Column<DateTime>(nullable: true),
                    thsa = table.Column<DateTime>(nullable: true),
                    frPeriod_Hours = table.Column<DateTime>(nullable: true),
                    frType = table.Column<bool>(nullable: false),
                    frh = table.Column<bool>(nullable: false),
                    frBonus = table.Column<bool>(nullable: false),
                    frf = table.Column<bool>(nullable: false),
                    frfs = table.Column<DateTime>(nullable: true),
                    frfe = table.Column<DateTime>(nullable: true),
                    frfa = table.Column<DateTime>(nullable: true),
                    frs = table.Column<bool>(nullable: false),
                    frss = table.Column<DateTime>(nullable: true),
                    frse = table.Column<DateTime>(nullable: true),
                    frsa = table.Column<DateTime>(nullable: true),
                    BonusCheck = table.Column<bool>(nullable: false),
                    LateCheck = table.Column<bool>(nullable: false),
                    AttEarly = table.Column<bool>(nullable: false),
                    LeaveEarly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worksyss", x => x.Id);
                });

          

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    WorksysId = table.Column<int>(nullable: false),
                    DepartId = table.Column<int>(nullable: true),
                    SecId = table.Column<int>(nullable: true),
                    DeviceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departs_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Departs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Secs_SecId",
                        column: x => x.SecId,
                        principalTable: "Secs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Worksyss_WorksysId",
                        column: x => x.WorksysId,
                        principalTable: "Worksyss",
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
                    DeviceId = table.Column<int>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOEdits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOEdits_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IOEdits_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
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
                    DeviceId = table.Column<int>(nullable: false),
                    Priority = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOs_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IOs_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartId",
                table: "Employees",
                column: "DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeviceId",
                table: "Employees",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SecId",
                table: "Employees",
                column: "SecId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorksysId",
                table: "Employees",
                column: "WorksysId");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_DeviceId",
                table: "IOEdits",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOEdits_EmpId",
                table: "IOEdits",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_DeviceId",
                table: "IOs",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_EmpId",
                table: "IOs",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IOEdits");

            migrationBuilder.DropTable(
                name: "IOs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departs");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Secs");

            migrationBuilder.DropTable(
                name: "Worksyss");
        }
    }
}
