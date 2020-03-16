using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class UpdateCategoriesAssignmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormId",
                table: "CategoriesAssignments",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Categories_CategoryId",
                table: "CategoriesAssignments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormId",
                table: "CategoriesAssignments",
                column: "FormId",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Categories_CategoryId",
                table: "CategoriesAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormId",
                table: "CategoriesAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesAssignments_FormId",
                table: "CategoriesAssignments");
        }
    }
}
