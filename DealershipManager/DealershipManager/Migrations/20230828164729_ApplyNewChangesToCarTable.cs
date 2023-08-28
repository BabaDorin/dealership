using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealershipManager.Migrations
{
    /// <inheritdoc />
    public partial class ApplyNewChangesToCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionYear",
                table: "Cars",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Cars",
                newName: "ProductionYear");
        }
    }
}
