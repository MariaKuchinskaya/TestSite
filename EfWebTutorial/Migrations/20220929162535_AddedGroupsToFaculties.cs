using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfWebTutorial.Migrations
{
    public partial class AddedGroupsToFaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Groups");
        }
    }
}
