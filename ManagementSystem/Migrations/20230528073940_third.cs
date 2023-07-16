using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Academic");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Academic",
                newName: "PassWord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Academic",
                table: "Academic",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Academic",
                table: "Academic");

            migrationBuilder.RenameTable(
                name: "Academic",
                newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Teachers",
                newName: "Password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");
        }
    }
}
