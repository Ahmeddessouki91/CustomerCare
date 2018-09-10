using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCare.Migrations
{
    public partial class AddRelationCustomerInteractionWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Interactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_UserId",
                table: "Interactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Users_UserId",
                table: "Interactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Users_UserId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_UserId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Interactions");
        }
    }
}
