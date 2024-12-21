using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateKey03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesCourseId",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseId",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_OfferedCourseId",
                table: "StudentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesCourseId",
                table: "InstructorOfferedCourse");

            migrationBuilder.AddColumn<int>(
                name: "OfferedCourseCourseId",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferedCourseYear",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferedCoursesYear",
                table: "InstructorOfferedCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses",
                columns: new[] { "CourseId", "Year" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse",
                columns: new[] { "InstructorsId", "OfferedCoursesCourseId", "OfferedCoursesYear" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseCourseId", "OfferedCourseYear" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesCourseId_OfferedCoursesYear",
                table: "InstructorOfferedCourse",
                columns: new[] { "OfferedCoursesCourseId", "OfferedCoursesYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesCourseId_OfferedCoursesYear",
                table: "InstructorOfferedCourse",
                columns: new[] { "OfferedCoursesCourseId", "OfferedCoursesYear" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "CourseId", "Year" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseCourseId", "OfferedCourseYear" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "CourseId", "Year" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesCourseId_OfferedCoursesYear",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_OfferedCourseCourseId_OfferedCourseYear",
                table: "StudentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesCourseId_OfferedCoursesYear",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCourseCourseId",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCourseYear",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCoursesYear",
                table: "InstructorOfferedCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse",
                columns: new[] { "InstructorsId", "OfferedCoursesCourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_OfferedCourseId",
                table: "StudentsCourse",
                column: "OfferedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesCourseId",
                table: "InstructorOfferedCourse",
                column: "OfferedCoursesCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesCourseId",
                table: "InstructorOfferedCourse",
                column: "OfferedCoursesCourseId",
                principalTable: "OfferedCourses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseId",
                table: "StudentsCourse",
                column: "OfferedCourseId",
                principalTable: "OfferedCourses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
