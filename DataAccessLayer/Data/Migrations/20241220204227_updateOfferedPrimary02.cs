﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateOfferedPrimary02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesClassRoom_OfferedCoursesTime",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseClassRoom_OfferedCourseTime",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_OfferedCourseClassRoom_OfferedCourseTime",
                table: "StudentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses");

            migrationBuilder.DropIndex(
                name: "IX_OfferedCourses_CourseId",
                table: "OfferedCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesClassRoom_OfferedCoursesTime",
                table: "InstructorOfferedCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCourseClassRoom",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCourseTime",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "OfferedCoursesTime",
                table: "InstructorOfferedCourse");

            migrationBuilder.RenameColumn(
                name: "OfferedCoursesClassRoom",
                table: "InstructorOfferedCourse",
                newName: "OfferedCoursesCourseId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "OfferedCoursesCourseId",
                table: "InstructorOfferedCourse",
                newName: "OfferedCoursesClassRoom");

            migrationBuilder.AddColumn<int>(
                name: "OfferedCourseClassRoom",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OfferedCourseTime",
                table: "StudentsCourse",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "OfferedCoursesTime",
                table: "InstructorOfferedCourse",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferedCourses",
                table: "OfferedCourses",
                columns: new[] { "ClassRoom", "Time" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorOfferedCourse",
                table: "InstructorOfferedCourse",
                columns: new[] { "InstructorsId", "OfferedCoursesClassRoom", "OfferedCoursesTime" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_OfferedCourseClassRoom_OfferedCourseTime",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseClassRoom", "OfferedCourseTime" });

            migrationBuilder.CreateIndex(
                name: "IX_OfferedCourses_CourseId",
                table: "OfferedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorOfferedCourse_OfferedCoursesClassRoom_OfferedCoursesTime",
                table: "InstructorOfferedCourse",
                columns: new[] { "OfferedCoursesClassRoom", "OfferedCoursesTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorOfferedCourse_OfferedCourses_OfferedCoursesClassRoom_OfferedCoursesTime",
                table: "InstructorOfferedCourse",
                columns: new[] { "OfferedCoursesClassRoom", "OfferedCoursesTime" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "ClassRoom", "Time" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_OfferedCourses_OfferedCourseClassRoom_OfferedCourseTime",
                table: "StudentsCourse",
                columns: new[] { "OfferedCourseClassRoom", "OfferedCourseTime" },
                principalTable: "OfferedCourses",
                principalColumns: new[] { "ClassRoom", "Time" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
