using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Articles_ArticleId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ArticleId",
                table: "Attachments");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Attachments_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Attachments_Id",
                table: "Articles");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ArticleId",
                table: "Attachments",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Articles_ArticleId",
                table: "Attachments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
