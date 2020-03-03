using Microsoft.EntityFrameworkCore.Migrations;

namespace Roomz.Migrations
{
    public partial class AddPlaceholders_BookerEmail_RoomId_ChosenRoomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookerEmail",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChosenRoomId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Schedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookerEmail",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ChosenRoomId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Schedules");
        }
    }
}
