using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1004_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class tempcharvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempClasses",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempLevel",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TempName",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempRace",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempClasses",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TempLevel",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TempName",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "TempRace",
                table: "Character");
        }
    }
}
