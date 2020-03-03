using Microsoft.EntityFrameworkCore.Migrations;

namespace Roomz.Migrations
{
    public partial class RemoveChoseRoomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenRoomId",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChosenRoomId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
