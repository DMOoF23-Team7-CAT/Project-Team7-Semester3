using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Api.Migrations
{
    /// <inheritdoc />
    public partial class EquipmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SignNumber",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Equipments");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XCoordinate",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YCoordinate",
                table: "Sign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "Sign");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "Sign");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SignNumber",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
