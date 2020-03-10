using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class FixingFormsFKCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormInfoId",
                table: "Forms");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Forms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                columns: new[] { "QuestionOrderNum", "OptionOrderNum", "FormId" });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormId",
                table: "Forms",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms",
                column: "FormId",
                principalTable: "FormsInfo",
                principalColumn: "FormInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormsInfo_FormId",
                table: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_FormId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Forms");

            migrationBuilder.AddColumn<int>(
                name: "FormInfoId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                columns: new[] { "QuestionOrderNum", "OptionOrderNum", "FormInfoId" });
        }
    }
}
