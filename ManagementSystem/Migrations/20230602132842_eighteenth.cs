using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class eighteenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_StudentId",
                table: "Module_Student",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Students_StudentId",
                table: "Module_Student",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Teachers_ModuleId",
                table: "Module_Student",
                column: "ModuleId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Students_StudentId",
                table: "Module_Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Teachers_ModuleId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_StudentId",
                table: "Module_Student");
        }
    }
}
