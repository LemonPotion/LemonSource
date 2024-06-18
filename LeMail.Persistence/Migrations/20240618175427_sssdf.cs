using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeMail.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class sssdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Attachments_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Reviews_Id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_Id",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<Guid>(
                name: "AttachmentId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AttachmentId",
                table: "Articles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ReviewId",
                table: "Articles",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Attachments_AttachmentId",
                table: "Articles",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Reviews_ReviewId",
                table: "Articles",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Attachments_AttachmentId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuthorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Reviews_ReviewId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AttachmentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ReviewId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "createDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Attachments_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Articles_Users_Id",
                table: "Articles",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
