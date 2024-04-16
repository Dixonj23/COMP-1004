using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1004_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the index 'IX_Character_ClassesClassId' if it exists
            migrationBuilder.DropIndex(
                name: "IX_Character_ClassesClassId",
                table: "Character"
            );

            // Drop any foreign key constraints associated with the ClassesClassId column if necessary
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_ClassesClassId",
                table: "Character"
            );

            // Remove the ClassesClassId column
            migrationBuilder.DropColumn(
                name: "ClassesClassId",
                table: "Character"
            );

            // Add the new Classes column
            migrationBuilder.AddColumn<string>(
                name: "Classes",
                table: "Character",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the changes in the Down method if necessary
            migrationBuilder.AddColumn<int>(
                name: "ClassesClassId",
                table: "Character",
                nullable: false,
                defaultValue: 0
            );

            // Add foreign key constraints if necessary
            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_ClassesClassId",
                table: "Character",
                column: "ClassesClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade
            );

            // Re-add the index 'IX_Character_ClassesClassId'
            migrationBuilder.CreateIndex(
                name: "IX_Character_ClassesClassId",
                table: "Character",
                column: "ClassesClassId"
            );

            // Drop the new Classes column
            migrationBuilder.DropColumn(
                name: "Classes",
                table: "Character"
            );
        }
    }
}
