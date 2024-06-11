using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    objective = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    genre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Local)),
                    views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("articleId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachmentId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nickName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    degree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("authorId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    objective = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reviewId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("issueId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reviewerId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviewers_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ArticleId",
                table: "Attachments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ArticleId",
                table: "Authors",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReviewId",
                table: "Issues",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_ReviewId",
                table: "Reviewers",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
