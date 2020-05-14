using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class Remove_PK_FormsCategoryAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormsCategoryAssignments_CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropIndex(
                name: "IX_FormsCategoryAssignments_CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
