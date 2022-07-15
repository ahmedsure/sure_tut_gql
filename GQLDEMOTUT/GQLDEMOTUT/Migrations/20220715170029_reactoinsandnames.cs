using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    public partial class reactoinsandnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Reactions_Posts_ReactedTOPost",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Users_ReactionBy",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersNetworks_Users_RelationFromUserID",
                table: "UsersNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersNetworks_Users_RelationToUserID",
                table: "UsersNetworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersNetworks",
                table: "UsersNetworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "UsersNetworks",
                newName: "GQLUsersNetwork");

            migrationBuilder.RenameTable(
                name: "Reactions",
                newName: "ReactToPosts");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentToPostOrComments");

            migrationBuilder.RenameIndex(
                name: "IX_UsersNetworks_RelationToUserID",
                table: "GQLUsersNetwork",
                newName: "IX_GQLUsersNetwork_RelationToUserID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersNetworks_RelationFromUserID",
                table: "GQLUsersNetwork",
                newName: "IX_GQLUsersNetwork_RelationFromUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ReactionBy",
                table: "ReactToPosts",
                newName: "IX_ReactToPosts_ReactionBy");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ReactedTOPost",
                table: "ReactToPosts",
                newName: "IX_ReactToPosts_ReactedTOPost");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentOnPostID",
                table: "CommentToPostOrComments",
                newName: "IX_CommentToPostOrComments_CommentOnPostID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentBy",
                table: "CommentToPostOrComments",
                newName: "IX_CommentToPostOrComments_CommentBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GQLUsersNetwork",
                table: "GQLUsersNetwork",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReactToPosts",
                table: "ReactToPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentToPostOrComments",
                table: "CommentToPostOrComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComments_CommentToPostOrComments_CommentOnPostID",
                table: "CommentToPostOrComments",
                column: "CommentOnPostID",
                principalTable: "CommentToPostOrComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComments_Posts_CommentOnPostID",
                table: "CommentToPostOrComments",
                column: "CommentOnPostID",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentToPostOrComments_Users_CommentBy",
                table: "CommentToPostOrComments",
                column: "CommentBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationFromUserID",
                table: "GQLUsersNetwork",
                column: "RelationFromUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationToUserID",
                table: "GQLUsersNetwork",
                column: "RelationToUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReactToPosts_Posts_ReactedTOPost",
                table: "ReactToPosts",
                column: "ReactedTOPost",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReactToPosts_Users_ReactionBy",
                table: "ReactToPosts",
                column: "ReactionBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComments_CommentToPostOrComments_CommentOnPostID",
                table: "CommentToPostOrComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComments_Posts_CommentOnPostID",
                table: "CommentToPostOrComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentToPostOrComments_Users_CommentBy",
                table: "CommentToPostOrComments");

            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationFromUserID",
                table: "GQLUsersNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationToUserID",
                table: "GQLUsersNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_ReactToPosts_Posts_ReactedTOPost",
                table: "ReactToPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReactToPosts_Users_ReactionBy",
                table: "ReactToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReactToPosts",
                table: "ReactToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GQLUsersNetwork",
                table: "GQLUsersNetwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentToPostOrComments",
                table: "CommentToPostOrComments");

            migrationBuilder.RenameTable(
                name: "ReactToPosts",
                newName: "Reactions");

            migrationBuilder.RenameTable(
                name: "GQLUsersNetwork",
                newName: "UsersNetworks");

            migrationBuilder.RenameTable(
                name: "CommentToPostOrComments",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_ReactToPosts_ReactionBy",
                table: "Reactions",
                newName: "IX_Reactions_ReactionBy");

            migrationBuilder.RenameIndex(
                name: "IX_ReactToPosts_ReactedTOPost",
                table: "Reactions",
                newName: "IX_Reactions_ReactedTOPost");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetwork_RelationToUserID",
                table: "UsersNetworks",
                newName: "IX_UsersNetworks_RelationToUserID");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetwork_RelationFromUserID",
                table: "UsersNetworks",
                newName: "IX_UsersNetworks_RelationFromUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentToPostOrComments_CommentOnPostID",
                table: "Comments",
                newName: "IX_Comments_CommentOnPostID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentToPostOrComments_CommentBy",
                table: "Comments",
                newName: "IX_Comments_CommentBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersNetworks",
                table: "UsersNetworks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsersNetworks_Users_RelationFromUserID",
                table: "UsersNetworks",
                column: "RelationFromUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersNetworks_Users_RelationToUserID",
                table: "UsersNetworks",
                column: "RelationToUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
