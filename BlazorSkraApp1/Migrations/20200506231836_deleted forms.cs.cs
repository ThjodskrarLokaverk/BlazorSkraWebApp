using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class deletedformscs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    QuestionOrderNum = table.Column<int>(type: "int", nullable: false),
                    OptionOrderNum = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    OptionsOptionId = table.Column<int>(type: "int", nullable: true),
                    QuestionsQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => new { x.QuestionOrderNum, x.OptionOrderNum, x.FormId });
                    table.ForeignKey(
                        name: "FK_Forms_FormsInfo_FormId",
                        column: x => x.FormId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Options_OptionsOptionId",
                        column: x => x.OptionsOptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forms_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormId",
                table: "Forms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_OptionsOptionId",
                table: "Forms",
                column: "OptionsOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_QuestionsQuestionId",
                table: "Forms",
                column: "QuestionsQuestionId");
        }
    }
}
