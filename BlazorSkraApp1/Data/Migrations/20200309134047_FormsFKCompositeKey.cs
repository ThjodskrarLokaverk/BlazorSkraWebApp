using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class FormsFKCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormsInfo_FormsInfoFormInfoId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Questions_QuestionsQuestionId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_FormsInfoFormInfoId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormsInfoFormInfoId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Forms");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionsQuestionId",
                table: "Forms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionsOptionId",
                table: "Forms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Questions_QuestionsQuestionId",
                table: "Forms",
                column: "QuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Questions_QuestionsQuestionId",
                table: "Forms");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionsQuestionId",
                table: "Forms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionsOptionId",
                table: "Forms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FormsInfoFormInfoId",
                table: "Forms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormsInfoFormInfoId",
                table: "Forms",
                column: "FormsInfoFormInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormsInfo_FormsInfoFormInfoId",
                table: "Forms",
                column: "FormsInfoFormInfoId",
                principalTable: "FormsInfo",
                principalColumn: "FormInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_QuestionOptions_QuestionOptionsOptionId",
                table: "Forms",
                column: "QuestionOptionsOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Questions_QuestionsQuestionId",
                table: "Forms",
                column: "QuestionsQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
