using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompensationRetirementEstimator.Api.Migrations
{
    /// <inheritdoc />
    public partial class LinkProjectionsToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RetirementSalary",
                table: "RetirementProjections",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_RetirementProjections_UserId",
                table: "RetirementProjections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetirementProjections_Users_UserId",
                table: "RetirementProjections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetirementProjections_Users_UserId",
                table: "RetirementProjections");

            migrationBuilder.DropIndex(
                name: "IX_RetirementProjections_UserId",
                table: "RetirementProjections");

            migrationBuilder.DropColumn(
                name: "RetirementSalary",
                table: "RetirementProjections");
        }
    }
}
