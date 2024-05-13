using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentBases_EquipmentBaseId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Signs_SignBases_SignBaseId",
                table: "Signs");

            migrationBuilder.DropForeignKey(
                name: "FK_Signs_Tracks_TrackId",
                table: "Signs");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Signs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SignBaseId",
                table: "Signs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentBaseId",
                table: "SignBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SignBases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentBaseId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentBases_EquipmentBaseId",
                table: "Equipment",
                column: "EquipmentBaseId",
                principalTable: "EquipmentBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_SignBases_SignBaseId",
                table: "Signs",
                column: "SignBaseId",
                principalTable: "SignBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_Tracks_TrackId",
                table: "Signs",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentBases_EquipmentBaseId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Signs_SignBases_SignBaseId",
                table: "Signs");

            migrationBuilder.DropForeignKey(
                name: "FK_Signs_Tracks_TrackId",
                table: "Signs");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Signs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SignBaseId",
                table: "Signs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentBaseId",
                table: "SignBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SignBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentBaseId",
                table: "Equipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentBases_EquipmentBaseId",
                table: "Equipment",
                column: "EquipmentBaseId",
                principalTable: "EquipmentBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_SignBases_SignBaseId",
                table: "Signs",
                column: "SignBaseId",
                principalTable: "SignBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_Tracks_TrackId",
                table: "Signs",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id");
        }
    }
}
