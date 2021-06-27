using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen2_DAV_AngelSevilla.Migrations
{
    public partial class AddedVaccinationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VaccinationDate",
                table: "VaccinationControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VaccinationDate",
                table: "VaccinationControls");
        }
    }
}
