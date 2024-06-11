using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Articles_ArticleId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Reviews_ReviewId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviewers_Reviews_ReviewId",
                table: "Reviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviewers_ReviewId",
                table: "Reviewers");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReviewId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ArticleId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Reviews_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Issues_Id",
                table: "Reviews",
                column: "Id",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_Id",
                table: "Reviews",
                column: "Id",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Articles_Id",
                table: "Users",
                column: "Id",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Reviews_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Issues_Id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_Id",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Articles_Id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_ReviewId",
                table: "Reviewers",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReviewId",
                table: "Issues",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ArticleId",
                table: "Authors",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Articles_ArticleId",
                table: "Authors",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Reviews_ReviewId",
                table: "Issues",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewers_Reviews_ReviewId",
                table: "Reviewers",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
