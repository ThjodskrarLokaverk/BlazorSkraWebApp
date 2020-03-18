using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class UpdateCategoriesAssignmentTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId",
                table: "CategoriesAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId",
                table: "CategoriesAssignments");

            migrationBuilder.DropColumn(
                name: "FormsInfoFormId",
                table: "CategoriesAssignments");

            migrationBuilder.AddColumn<int>(
                name: "FormsInfoFormId1",
                table: "CategoriesAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId1",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId1",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId1",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.DropColumn(
                name: "FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.AddColumn<int>(
                name: "FormsInfoFormId",
                table: "CategoriesAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
