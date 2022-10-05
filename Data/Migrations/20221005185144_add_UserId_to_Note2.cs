using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class add_UserId_to_Note2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Notes",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notes",
                newName: "User");
        }
    }
}
