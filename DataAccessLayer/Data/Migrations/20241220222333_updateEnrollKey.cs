using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateEnrollKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCourseCourseId",
                table: "StudentsCourse");

            migrationBuilder.RenameColumn(
                name: "OfferedCourseYear",
                table: "StudentsCourse",
                newName: "Year");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                columns: new[] { "StudentId", "OfferedCourseId", "Year" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_OfferedCourseId_Year",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseId", "Year" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseId_Year",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseId", "Year" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "CourseId", "Year" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseId_Year",
                table: "StudentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_OfferedCourseId_Year",
                table: "StudentsCourse");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "StudentsCourse",
                newName: "OfferedCourseYear");

            migrationBuilder.AddColumn<int>(
                name: "OfferedCourseCourseId",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                columns: new[] { "StudentId", "OfferedCourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseCourseId", "OfferedCourseYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseCourseId", "OfferedCourseYear" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "CourseId", "Year" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
