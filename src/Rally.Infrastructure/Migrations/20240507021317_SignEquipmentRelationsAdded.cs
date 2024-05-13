using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SignEquipmentRelationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Signs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Signs_EquipmentId",
                table: "Signs",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_Equipment_EquipmentId",
                table: "Signs",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signs_Equipment_EquipmentId",
                table: "Signs");

            migrationBuilder.DropIndex(
                name: "IX_Signs_EquipmentId",
                table: "Signs");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Signs");
        }
    }
}
