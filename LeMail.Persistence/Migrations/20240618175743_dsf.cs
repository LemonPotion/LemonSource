using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Reviews_ReviewId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ReviewId",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ReviewId",
                table: "Articles",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Reviews_ReviewId",
                table: "Articles",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
