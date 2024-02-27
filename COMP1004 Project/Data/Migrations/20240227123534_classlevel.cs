using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1004_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class classlevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassLevel",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassLevel",
                table: "Character");
        }
    }
}
