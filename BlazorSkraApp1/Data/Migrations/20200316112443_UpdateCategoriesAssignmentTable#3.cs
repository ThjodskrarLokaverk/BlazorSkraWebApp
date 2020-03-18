using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class UpdateCategoriesAssignmentTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Categories_CategoriesCategoryId",
                table: "CategoriesAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormId",
                table: "CategoriesAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Formsinfo_FormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Formsinfo_FormId",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formsinfo",
                table: "Formsinfo");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesAssignments_CategoriesCategoryId",
                table: "CategoriesAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "CategoriesAssignments");

            migrationBuilder.DropColumn(
                name: "FormsInfoFormId1",
                table: "CategoriesAssignments");

            migrationBuilder.RenameTable(
                name: "Formsinfo",
                newName: "FormsInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_FormsInfo_FormId",
                table: "CategoriesAssignments",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_FormsInfo_FormId",
                table: "Submissions",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesAssignments_FormsInfo_FormId",
                table: "CategoriesAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_FormsInfo_FormId",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo");

            migrationBuilder.RenameTable(
                name: "FormsInfo",
                newName: "Formsinfo");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "CategoriesAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormsInfoFormId1",
                table: "CategoriesAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formsinfo",
                table: "Formsinfo",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_CategoriesCategoryId",
                table: "CategoriesAssignments",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId1",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Categories_CategoriesCategoryId",
                table: "CategoriesAssignments",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormId",
                table: "CategoriesAssignments",
                column: "FormId",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId1",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId1",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Formsinfo_FormId",
                table: "Forms",
                column: "FormId",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Formsinfo_FormId",
                table: "Submissions",
                column: "FormId",
                principalTable: "Formsinfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
