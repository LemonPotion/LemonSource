using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Reviewers");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IssueId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewerId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Reviewers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Attachments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
