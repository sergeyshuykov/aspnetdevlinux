using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCMigration.Migrations
{
    /// <inheritdoc />
    public partial class SecondVer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "People",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "People");
        }
    }
}
