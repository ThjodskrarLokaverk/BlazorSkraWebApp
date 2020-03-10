using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class CreateFormsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "FormsInfo");

            migrationBuilder.AddColumn<int>(
                name: "FormInfoId",
                table: "FormsInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormInfoId");

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    QuestionOrderNum = table.Column<int>(nullable: false),
                    OptionOrderNum = table.Column<int>(nullable: false),
                    FormInfoId = table.Column<int>(nullable: false),
                    FormsInfoFormInfoId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    QuestionsQuestionId = table.Column<int>(nullable: true),
                    OptionId = table.Column<int>(nullable: false),
                    QuestionOptionsOptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => new { x.QuestionOrderNum, x.OptionOrderNum, x.FormInfoId });
                    table.ForeignKey(
                        name: "FK_Forms_FormsInfo_FormsInfoFormInfoId",
                        column: x => x.FormsInfoFormInfoId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                        column: x => x.QuestionOptionsOptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forms_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormsInfoFormInfoId",
                table: "Forms",
                column: "FormsInfoFormInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_QuestionsQuestionId",
                table: "Forms",
                column: "QuestionsQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo");

            migrationBuilder.DropColumn(
                name: "FormInfoId",
                table: "FormsInfo");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "FormsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormId");
        }
    }
}
