using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    public partial class modifingOffered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing column
            migrationBuilder.DropColumn(
                name: "Time",
                table: "OfferedCourses");

            // Add the new column with the correct type
            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "OfferedCourses",
                type: "time",
                nullable: false,
                defaultValue: TimeOnly.MinValue); // Default to 00:00:00
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new column
            migrationBuilder.DropColumn(
                name: "Time",
                table: "OfferedCourses");

            // Re-add the old column
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "OfferedCourses",
                type: "int",
                nullable: false,
                defaultValue: 0); // Default to 0
        }
    }
}
