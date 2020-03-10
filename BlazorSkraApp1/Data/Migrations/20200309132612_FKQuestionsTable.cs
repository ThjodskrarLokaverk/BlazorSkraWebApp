using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class FKQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypesQuestionTypeId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTypesQuestionTypeId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypesQuestionTypeId",
                table: "Questions",
                column: "QuestionTypesQuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "QuestionTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypesQuestionTypeId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTypesQuestionTypeId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypesQuestionTypeId",
                table: "Questions",
                column: "QuestionTypesQuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "QuestionTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
