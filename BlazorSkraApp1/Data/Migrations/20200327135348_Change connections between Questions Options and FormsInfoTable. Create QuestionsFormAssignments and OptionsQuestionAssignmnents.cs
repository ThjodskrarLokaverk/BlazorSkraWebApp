using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class ChangeconnectionsbetweenQuestionsOptionsandFormsInfoTableCreateQuestionsFormAssignmentsandOptionsQuestionAssignmnents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_Forms_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.AddColumn<int>(
                name: "OptionsOptionId",
                table: "Forms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsFormAssignments",
                columns: table => new
                {
                    FormId = table.Column<int>(nullable: false),
                    QuestionOrderNum = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsFormAssignments", x => new { x.FormId, x.QuestionOrderNum });
                    table.ForeignKey(
                        name: "FK_QuestionsFormAssignments_FormsInfo_FormId",
                        column: x => x.FormId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsFormAssignments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionsQuestionAssignmnents",
                columns: table => new
                {
                    OptionOrderNum = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    QuestionOrderNum = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsQuestionAssignmnents", x => new { x.FormId, x.QuestionOrderNum, x.OptionOrderNum });
                    table.ForeignKey(
                        name: "FK_OptionsQuestionAssignmnents_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionsQuestionAssignmnents_QuestionsFormAssignments_FormId_QuestionOrderNum",
                        columns: x => new { x.FormId, x.QuestionOrderNum },
                        principalTable: "QuestionsFormAssignments",
                        principalColumns: new[] { "FormId", "QuestionOrderNum" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_OptionsOptionId",
                table: "Forms",
                column: "OptionsOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsQuestionAssignmnents_OptionId",
                table: "OptionsQuestionAssignmnents",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsFormAssignments_QuestionId",
                table: "QuestionsFormAssignments",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Options_OptionsOptionId",
                table: "Forms",
                column: "OptionsOptionId",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Options_OptionsOptionId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "OptionsQuestionAssignmnents");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "QuestionsFormAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Forms_OptionsOptionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "OptionsOptionId",
                table: "Forms");

            migrationBuilder.AddColumn<int>(
                name: "QuestionOptionsOptionId",
                table: "Forms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.OptionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
