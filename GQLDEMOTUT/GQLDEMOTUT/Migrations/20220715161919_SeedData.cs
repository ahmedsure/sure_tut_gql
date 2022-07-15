using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComment_CommentToPostOrComment_CommentOnPostID",
                table: "CommentToPostOrComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComment_GQLUser_CommentBy",
                table: "CommentToPostOrComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComment_Post_CommentOnPostID",
                table: "CommentToPostOrComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GQLUser_PostedBy",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_ReactToPost_GQLUser_ReactionBy",
                table: "ReactToPost");

            migrationBuilder.DropForeignKey(
                name: "FK_ReactToPost_Post_ReactedTOPost",
                table: "ReactToPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReactToPost",
                table: "ReactToPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GQLUser",
                table: "GQLUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentToPostOrComment",
                table: "CommentToPostOrComment");

            migrationBuilder.RenameTable(
                name: "ReactToPost",
                newName: "Reactions");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "GQLUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "CommentToPostOrComment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_ReactToPost_ReactionBy",
                table: "Reactions",
                newName: "IX_Reactions_ReactionBy");

            migrationBuilder.RenameIndex(
                name: "IX_ReactToPost_ReactedTOPost",
                table: "Reactions",
                newName: "IX_Reactions_ReactedTOPost");

            migrationBuilder.RenameIndex(
                name: "IX_Post_PostedBy",
                table: "Posts",
                newName: "IX_Posts_PostedBy");

            migrationBuilder.RenameIndex(
                name: "IX_CommentToPostOrComment_CommentOnPostID",
                table: "Comments",
                newName: "IX_Comments_CommentOnPostID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentToPostOrComment_CommentBy",
                table: "Comments",
                newName: "IX_Comments_CommentBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("01b55555-955b-45a8-b6fe-efce8162a755"), "Sec User " });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"), "First User Of APP" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "PostContent", "PostedBy", "PostedOn" },
                values: new object[] { new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"), "Hi , This Is My First Post Here ", new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"), new DateTime(11, 11, 11, 12, 30, 30, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentBy", "CommentContent", "CommentOnCommentID", "CommentOnPostID", "CommentedOn" },
                values: new object[] { new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"), new Guid("01b55555-955b-45a8-b6fe-efce8162a755"), "Hi , Welcome ", null, new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"), new DateTime(11, 11, 11, 12, 30, 30, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentOnPostID",
                table: "Comments",
                column: "CommentOnPostID",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentOnPostID",
                table: "Comments",
                column: "CommentOnPostID",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CommentBy",
                table: "Comments",
                column: "CommentBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PostedBy",
                table: "Posts",
                column: "PostedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_ReactedTOPost",
                table: "Reactions",
                column: "ReactedTOPost",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Users_ReactionBy",
                table: "Reactions",
                column: "ReactionBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentOnPostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentOnPostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CommentBy",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PostedBy",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_ReactedTOPost",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Users_ReactionBy",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f1b72222-9bbb-45a8-b6fe-efce8162a7db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01b55555-955b-45a8-b6fe-efce8162a755"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"));

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "GQLUser");

            migrationBuilder.RenameTable(
                name: "Reactions",
                newName: "ReactToPost");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentToPostOrComment");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ReactionBy",
                table: "ReactToPost",
                newName: "IX_ReactToPost_ReactionBy");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ReactedTOPost",
                table: "ReactToPost",
                newName: "IX_ReactToPost_ReactedTOPost");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostedBy",
                table: "Post",
                newName: "IX_Post_PostedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentOnPostID",
                table: "CommentToPostOrComment",
                newName: "IX_CommentToPostOrComment_CommentOnPostID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentBy",
                table: "CommentToPostOrComment",
                newName: "IX_CommentToPostOrComment_CommentBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GQLUser",
                table: "GQLUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReactToPost",
                table: "ReactToPost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentToPostOrComment",
                table: "CommentToPostOrComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComment_CommentToPostOrComment_CommentOnPostID",
                table: "CommentToPostOrComment",
                column: "CommentOnPostID",
                principalTable: "CommentToPostOrComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComment_GQLUser_CommentBy",
                table: "CommentToPostOrComment",
                column: "CommentBy",
                principalTable: "GQLUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComment_Post_CommentOnPostID",
                table: "CommentToPostOrComment",
                column: "CommentOnPostID",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GQLUser_PostedBy",
                table: "Post",
                column: "PostedBy",
                principalTable: "GQLUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReactToPost_GQLUser_ReactionBy",
                table: "ReactToPost",
                column: "ReactionBy",
                principalTable: "GQLUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReactToPost_Post_ReactedTOPost",
                table: "ReactToPost",
                column: "ReactedTOPost",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
