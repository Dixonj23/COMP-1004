using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1004_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class idnoclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Class",
                newName: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Class",
                newName: "ClassId"
            );
        }
    }
}
