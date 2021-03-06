﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSkraApp1.Migrations
{
    public partial class Add_FK_Remove_PK_FormsCategoryAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsCategoryAssignments",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropIndex(
                name: "IX_FormsCategoryAssignments_CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropIndex(
                name: "IX_FormsCategoryAssignments_FormId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsCategoryAssignments",
                table: "FormsCategoryAssignments",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsCategoryAssignments_CategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormsCategoryAssignments",
                table: "FormsCategoryAssignments");

            migrationBuilder.DropIndex(
                name: "IX_FormsCategoryAssignments_CategoryId",
                table: "FormsCategoryAssignments");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormsCategoryAssignments",
                table: "FormsCategoryAssignments",
                columns: new[] { "CategoryId", "FormId" });

            migrationBuilder.CreateIndex(
                name: "IX_FormsCategoryAssignments_CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsCategoryAssignments_FormId",
                table: "FormsCategoryAssignments",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsCategoryAssignments_Categories_CategoriesCategoryId",
                table: "FormsCategoryAssignments",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
