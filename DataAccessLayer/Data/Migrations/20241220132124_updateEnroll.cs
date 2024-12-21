using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateEnroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_StudentId",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentsCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                columns: new[] { "StudentId", "OfferedCourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentsCourse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourse",
                table: "StudentsCourse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_StudentId",
                table: "StudentsCourse",
                column: "StudentId");
        }
    }
}
