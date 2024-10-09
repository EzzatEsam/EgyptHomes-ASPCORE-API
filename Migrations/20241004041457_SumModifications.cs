using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgyptHomes.Migrations
{
    /// <inheritdoc />
    public partial class SumModifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyWorth",
                table: "Properties");

            migrationBuilder.AddColumn<bool>(
                name: "HasAirConditioning",
                table: "Properties",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasGarden",
                table: "Properties",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasSwimmingPool",
                table: "Properties",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Properties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAirConditioning",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HasGarden",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HasSwimmingPool",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Properties");

            migrationBuilder.AddColumn<float>(
                name: "PropertyWorth",
                table: "Properties",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
