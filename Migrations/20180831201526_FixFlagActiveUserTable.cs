using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCare.Migrations
{
    public partial class FixFlagActiveUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "Deactive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deactive",
                table: "Users",
                newName: "Active");
        }
    }
}
