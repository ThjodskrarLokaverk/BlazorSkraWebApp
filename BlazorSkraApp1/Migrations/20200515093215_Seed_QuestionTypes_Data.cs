﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class Seed_QuestionTypes_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "QuestionTypeId", "QuestionType", "QuestionTypeName" },
                values: new object[,]
                {
                    { -1, "ShortText", "Stuttur texti" },
                    { -2, "LongText", "Langur texti" },
                    { -3, "Radio", "Einval" },
                    { -4, "Checkbox", "Fjölval" },
                    { -5, "Date", "Dagsetning" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeId",
                keyValue: -1);
        }
    }
}
