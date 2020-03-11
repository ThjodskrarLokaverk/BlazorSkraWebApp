using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class Categories_CategoriesAssignments_Created_ConnectedToFormsInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formsinfo",
                table: "Formsinfo",
                column: "FormId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesAssignments",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    CategoriesCategoryId = table.Column<int>(nullable: true),
                    FormsInfoFormId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesAssignments", x => new { x.CategoryId, x.FormId });
                    table.ForeignKey(
                        name: "FK_CategoriesAssignments_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriesAssignments_Formsinfo_FormsInfoFormId",
                        column: x => x.FormsInfoFormId,
                        principalTable: "Formsinfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_CategoriesCategoryId",
                table: "CategoriesAssignments",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormsInfoFormId",
                table: "CategoriesAssignments",
                column: "FormsInfoFormId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Formsinfo_FormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Formsinfo_FormId",
                table: "Submissions");

            migrationBuilder.DropTable(
                name: "CategoriesAssignments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formsinfo",
                table: "Formsinfo");

            migrationBuilder.RenameTable(
                name: "Formsinfo",
                newName: "FormsInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormId");

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
    }
}
