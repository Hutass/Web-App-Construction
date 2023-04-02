using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebLab2.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Position",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Position",
                table: "TestResult");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "TestResult",
                newName: "TestID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_PositionID",
                table: "TestResult",
                newName: "IX_TestResult_TestID");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "Question",
                newName: "TestID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_PositionID",
                table: "Question",
                newName: "IX_Question_TestID");

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Test",
                table: "Question",
                column: "TestID",
                principalTable: "Test",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Test",
                table: "TestResult",
                column: "TestID",
                principalTable: "Test",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Test",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResult_Test",
                table: "TestResult");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "TestResult",
                newName: "PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_TestResult_TestID",
                table: "TestResult",
                newName: "IX_TestResult_PositionID");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "Question",
                newName: "PositionID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TestID",
                table: "Question",
                newName: "IX_Question_PositionID");

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Position",
                table: "Question",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResult_Position",
                table: "TestResult",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "ID");
        }
    }
}
