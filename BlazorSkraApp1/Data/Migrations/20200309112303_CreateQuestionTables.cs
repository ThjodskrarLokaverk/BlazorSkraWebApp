using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Data.Migrations
{
    public partial class CreateQuestionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList");

            migrationBuilder.RenameTable(
                name: "ToDoList",
                newName: "ToDo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDo",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "ToDoList");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDoList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList",
                column: "Id");
        }
    }
}
