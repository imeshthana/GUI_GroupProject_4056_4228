using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class seventeenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Students_StudentId",
                table: "Module_Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Teachers_TeacherId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_StudentId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_TeacherId",
                table: "Module_Student");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Module_Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Module_Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_StudentId",
                table: "Module_Student",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_TeacherId",
                table: "Module_Student",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Students_StudentId",
                table: "Module_Student",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Teachers_TeacherId",
                table: "Module_Student",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
