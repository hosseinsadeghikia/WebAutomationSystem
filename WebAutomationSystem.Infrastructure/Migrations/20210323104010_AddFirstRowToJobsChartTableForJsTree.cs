using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.Infrastructure.Migrations
{
    public partial class AddFirstRowToJobsChartTableForJsTree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.JobsCharts(Name,Description,Level)VALUES(N'مدیرعامل',N'بالاترین رده سازمانی',0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
