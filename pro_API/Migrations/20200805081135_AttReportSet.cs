using Microsoft.EntityFrameworkCore.Migrations;

namespace pro_API.Migrations
{
    public partial class AttReportSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttReportSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<bool>(nullable: false),
                    Day = table.Column<bool>(nullable: false),
                    Attend1 = table.Column<bool>(nullable: false),
                    EarlyAttend1 = table.Column<bool>(nullable: false),
                    Late1 = table.Column<bool>(nullable: false),
                    Depart1 = table.Column<bool>(nullable: false),
                    EarlyDepart1 = table.Column<bool>(nullable: false),
                    Bonus1 = table.Column<bool>(nullable: false),
                    Shift1 = table.Column<bool>(nullable: false),
                    Attend2 = table.Column<bool>(nullable: false),
                    EarlyAttend2 = table.Column<bool>(nullable: false),
                    Late2 = table.Column<bool>(nullable: false),
                    Depart2 = table.Column<bool>(nullable: false),
                    EarlyDepart2 = table.Column<bool>(nullable: false),
                    Bonus2 = table.Column<bool>(nullable: false),
                    Shift2 = table.Column<bool>(nullable: false),
                    Early = table.Column<bool>(nullable: false),
                    Late = table.Column<bool>(nullable: false),
                    EarlyDepart = table.Column<bool>(nullable: false),
                    Bonus = table.Column<bool>(nullable: false),
                    TotalTime = table.Column<bool>(nullable: false),
                    TotalSubtract = table.Column<bool>(nullable: false),
                    TotalSupplement = table.Column<bool>(nullable: false),
                    TotalHours = table.Column<bool>(nullable: false),
                    Holiday = table.Column<bool>(nullable: false),
                    Absent = table.Column<bool>(nullable: false),
                    AttendDevice = table.Column<bool>(nullable: false),
                    DepartDevice = table.Column<bool>(nullable: false),
                    Worksys = table.Column<bool>(nullable: false),
                    BonusType = table.Column<bool>(nullable: false),
                    UpdatedActions = table.Column<bool>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttReportSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttReportSet");
        }
    }
}
