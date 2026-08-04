using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompensationRetirementEstimator.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetirementProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContributionRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    EmployerMatchRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    InvestmentGrowthRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    RetirementAge = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectedMonthlyIncome = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirementProjections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentSalary = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetirementProjections");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
