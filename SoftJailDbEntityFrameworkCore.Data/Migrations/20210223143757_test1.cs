﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftJailDbEntityFrameworkCore.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners",
                column: "OfficerId",
                principalTable: "Officers",
                principalColumn: "OfficerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners",
                column: "PrisonerId",
                principalTable: "Prisoners",
                principalColumn: "PrisonerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Officers_OfficerId",
                table: "OfficerPrisoners",
                column: "OfficerId",
                principalTable: "Officers",
                principalColumn: "OfficerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerPrisoners_Prisoners_PrisonerId",
                table: "OfficerPrisoners",
                column: "PrisonerId",
                principalTable: "Prisoners",
                principalColumn: "PrisonerId");
        }
    }
}
