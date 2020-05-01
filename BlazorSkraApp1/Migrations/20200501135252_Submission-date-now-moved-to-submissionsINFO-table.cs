using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class SubmissiondatenowmovedtosubmissionsINFOtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "Submissions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubmissionsInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "SubmissionsInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "SubmissionsInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubmissionsInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "Submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
