using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prequestes_Courses_PrerequisitForId",
                table: "Prequestes");

            migrationBuilder.RenameColumn(
                name: "PrerequisitForId",
                table: "Prequestes",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Prequestes_PrerequisitForId",
                table: "Prequestes",
                newName: "IX_Prequestes_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prequestes_Courses_CourseId",
                table: "Prequestes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prequestes_Courses_CourseId",
                table: "Prequestes");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Prequestes",
                newName: "PrerequisitForId");

            migrationBuilder.RenameIndex(
                name: "IX_Prequestes_CourseId",
                table: "Prequestes",
                newName: "IX_Prequestes_PrerequisitForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prequestes_Courses_PrerequisitForId",
                table: "Prequestes",
                column: "PrerequisitForId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
