using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    public partial class InitSocialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GQLUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GQLUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostContent = table.Column<string>(type: "TEXT", nullable: false),
                    PostedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_GQLUser_PostedBy",
                        column: x => x.PostedBy,
                        principalTable: "GQLUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentToPostOrComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommentBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommentOnPostID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommentOnCommentID = table.Column<Guid>(type: "TEXT", nullable: true),
                    CommentContent = table.Column<string>(type: "TEXT", nullable: false),
                    CommentedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentToPostOrComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentToPostOrComment_CommentToPostOrComment_CommentOnPostID",
                        column: x => x.CommentOnPostID,
                        principalTable: "CommentToPostOrComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentToPostOrComment_GQLUser_CommentBy",
                        column: x => x.CommentBy,
                        principalTable: "GQLUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentToPostOrComment_Post_CommentOnPostID",
                        column: x => x.CommentOnPostID,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactToPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReactionBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReactedTOPost = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReactionTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    ReactToPostOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactToPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactToPost_GQLUser_ReactionBy",
                        column: x => x.ReactionBy,
                        principalTable: "GQLUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactToPost_Post_ReactedTOPost",
                        column: x => x.ReactedTOPost,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentToPostOrComment_CommentBy",
                table: "CommentToPostOrComment",
                column: "CommentBy");

            migrationBuilder.CreateIndex(
                name: "IX_CommentToPostOrComment_CommentOnPostID",
                table: "CommentToPostOrComment",
                column: "CommentOnPostID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostedBy",
                table: "Post",
                column: "PostedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReactToPost_ReactedTOPost",
                table: "ReactToPost",
                column: "ReactedTOPost");

            migrationBuilder.CreateIndex(
                name: "IX_ReactToPost_ReactionBy",
                table: "ReactToPost",
                column: "ReactionBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentToPostOrComment");

            migrationBuilder.DropTable(
                name: "ReactToPost");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "GQLUser");
        }
    }
}
