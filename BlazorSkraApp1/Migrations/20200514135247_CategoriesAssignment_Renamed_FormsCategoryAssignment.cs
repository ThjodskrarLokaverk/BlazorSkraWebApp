using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class CategoriesAssignment_Renamed_FormsCategoryAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesAssignments");

            migrationBuilder.CreateTable(
                name: "FormsCategoryAssignments",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsCategoryAssignments", x => new { x.CategoryId, x.FormId });
                    table.ForeignKey(
                        name: "FK_FormsCategoryAssignments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormsCategoryAssignments_FormsInfo_FormId",
                        column: x => x.FormId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormsCategoryAssignments_FormId",
                table: "FormsCategoryAssignments",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormsCategoryAssignments");

            migrationBuilder.CreateTable(
                name: "CategoriesAssignments",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesAssignments", x => new { x.CategoryId, x.FormId });
                    table.ForeignKey(
                        name: "FK_CategoriesAssignments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesAssignments_FormsInfo_FormId",
                        column: x => x.FormId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAssignments_FormId",
                table: "CategoriesAssignments",
                column: "FormId");
        }
    }
}
