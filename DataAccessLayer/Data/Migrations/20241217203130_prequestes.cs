using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class prequestes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prequestes",
                columns: table => new
                {
                    PrerequisitId = table.Column<int>(type: "int", nullable: false),
                    PrerequisitForId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prequestes", x => new { x.PrerequisitId, x.PrerequisitForId });
                    table.ForeignKey(
                        name: "FK_Prequestes_Courses_PrerequisitForId",
                        column: x => x.PrerequisitForId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prequestes_Courses_PrerequisitId",
                        column: x => x.PrerequisitId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prequestes_PrerequisitForId",
                table: "Prequestes",
                column: "PrerequisitForId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prequestes");
        }
    }
}
