using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class CreateSubmissionAndSubmissionsInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo");

            migrationBuilder.DropColumn(
                name: "FormInfoId",
                table: "FormsInfo");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionTypeName",
                table: "QuestionTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "Questions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "QuestionOptions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FormName",
                table: "FormsInfo",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "FormsInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionsOptionId",
                table: "Forms",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormId");

            migrationBuilder.CreateTable(
                name: "SubmissionsInfo",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionsInfo", x => x.SubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    QuestionOrderNum = table.Column<int>(nullable: false),
                    AnswerOrderNum = table.Column<int>(nullable: false),
                    SubmissionId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    QuestionsQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => new { x.SubmissionId, x.FormId, x.QuestionOrderNum, x.AnswerOrderNum });
                    table.ForeignKey(
                        name: "FK_Submissions_FormsInfo_FormId",
                        column: x => x.FormId,
                        principalTable: "FormsInfo",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Questions_QuestionsQuestionId",
                        column: x => x.QuestionsQuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_SubmissionsInfo_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "SubmissionsInfo",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_FormId",
                table: "Submissions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_QuestionsQuestionId",
                table: "Submissions",
                column: "QuestionsQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "SubmissionsInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "FormsInfo");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionTypeName",
                table: "QuestionTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "Questions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "QuestionOptions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FormName",
                table: "FormsInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "FormInfoId",
                table: "FormsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionsOptionId",
                table: "Forms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsInfo",
                table: "FormsInfo",
                column: "FormInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
