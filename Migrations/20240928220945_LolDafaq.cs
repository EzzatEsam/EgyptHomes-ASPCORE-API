using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgyptHomes.Migrations
{
    /// <inheritdoc />
    public partial class LolDafaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "Properties",
                type: "real using \"Value\"::real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Properties",
                type: "text",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
