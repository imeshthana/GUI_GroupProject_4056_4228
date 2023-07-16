using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class sixteenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Teachers_ModuleId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Module_Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_TeacherId",
                table: "Module_Student",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Teachers_TeacherId",
                table: "Module_Student",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Student_Teachers_TeacherId",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_TeacherId",
                table: "Module_Student");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Module_Student");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Student_Teachers_ModuleId",
                table: "Module_Student",
                column: "ModuleId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
