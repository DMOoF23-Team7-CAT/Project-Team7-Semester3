using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rally.Api.Migrations
{
    /// <inheritdoc />
    public partial class NameChangeForCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_CategoryTypes_CategoryTypeId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryExercise_categories_CategoriesId",
                table: "CategoryExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_categories_CategoryId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_categories_CategoryTypeId",
                table: "Categories",
                newName: "IX_Categories_CategoryTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryTypes_CategoryTypeId",
                table: "Categories",
                column: "CategoryTypeId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryExercise_Categories_CategoriesId",
                table: "CategoryExercise",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryTypes_CategoryTypeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryExercise_Categories_CategoriesId",
                table: "CategoryExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryTypeId",
                table: "categories",
                newName: "IX_categories_CategoryTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_CategoryTypes_CategoryTypeId",
                table: "categories",
                column: "CategoryTypeId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryExercise_categories_CategoriesId",
                table: "CategoryExercise",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_categories_CategoryId",
                table: "Tracks",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
