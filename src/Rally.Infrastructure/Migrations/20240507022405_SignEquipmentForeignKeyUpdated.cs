using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SignEquipmentForeignKeyUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SignId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_SignId",
                table: "Equipment",
                column: "SignId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Signs_SignId",
                table: "Equipment",
                column: "SignId",
                principalTable: "Signs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Signs_SignId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_SignId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "SignId",
                table: "Equipment");

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
    }
}
