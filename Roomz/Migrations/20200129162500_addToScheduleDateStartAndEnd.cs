using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Roomz.Migrations
{
    public partial class addToScheduleDateStartAndEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "Schedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDateEnd",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDateStart",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDateEnd",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "AppointmentDateStart",
                table: "Schedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
