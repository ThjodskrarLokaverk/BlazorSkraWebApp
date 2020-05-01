using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class QuestionTypeOrderNum_AddedTo_QustionsFormAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "Submissions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeOrderNum",
                table: "QuestionsFormAssignments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTypeOrderNum",
                table: "QuestionsFormAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "Submissions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
