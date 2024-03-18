using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Exercises",
                newName: "ExerciseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ExerciseId",
                table: "Exercises",
                newName: "IX_Exercises_ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "ExerciseTypeId",
                table: "Exercises",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ExerciseTypeId",
                table: "Exercises",
                newName: "IX_Exercises_ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseId",
                table: "Exercises",
                column: "ExerciseId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
