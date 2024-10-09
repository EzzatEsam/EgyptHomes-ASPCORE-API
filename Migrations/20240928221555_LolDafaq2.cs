using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgyptHomes.Migrations
{
    /// <inheritdoc />
    public partial class LolDafaq2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Properties",
                newName: "PropertyWorth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyWorth",
                table: "Properties",
                newName: "Value");
        }
    }
}
