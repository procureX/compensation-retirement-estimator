using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetirementProjectionCalculator.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentSalary = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetirementProjections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnnualContribution = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExpectedReturnRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    RetirementAge = table.Column<int>(type: "INTEGER", nullable: false),
                    Years = table.Column<string>(type: "TEXT", nullable: false),
                    Balances = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetirementProjections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetirementProjections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetirementProjections_UserId",
                table: "RetirementProjections",
                column: "UserId");
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
