using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class eleventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModules_Students_StudentId",
                table: "StudentModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentModules",
                table: "StudentModules");

            migrationBuilder.DropColumn(
                name: "ModuleCode",
                table: "StudentModules");

            migrationBuilder.RenameTable(
                name: "StudentModules",
                newName: "Module_Student");

            migrationBuilder.RenameIndex(
                name: "IX_StudentModules_StudentId",
                table: "Module_Student",
                newName: "IX_Module_Student_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Module_Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module_Student",
                table: "Module_Student",
                column: "StudentModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student",
                column: "ModuleId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module_Student",
                table: "Module_Student");

            migrationBuilder.DropIndex(
                name: "IX_Module_Student_ModuleId",
                table: "Module_Student");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Module_Student");

            migrationBuilder.RenameTable(
                name: "Module_Student",
                newName: "StudentModules");

            migrationBuilder.RenameIndex(
                name: "IX_Module_Student_StudentId",
                table: "StudentModules",
                newName: "IX_StudentModules_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "ModuleCode",
                table: "StudentModules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentModules",
                table: "StudentModules",
                column: "StudentModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModules_Students_StudentId",
                table: "StudentModules",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
