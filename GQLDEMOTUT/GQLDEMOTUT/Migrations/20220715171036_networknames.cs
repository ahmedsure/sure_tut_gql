using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    public partial class networknames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationFromUserID",
                table: "GQLUsersNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetwork_Users_RelationToUserID",
                table: "GQLUsersNetwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GQLUsersNetwork",
                table: "GQLUsersNetwork");

            migrationBuilder.RenameTable(
                name: "GQLUsersNetwork",
                newName: "GQLUsersNetworks");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetwork_RelationToUserID",
                table: "GQLUsersNetworks",
                newName: "IX_GQLUsersNetworks_RelationToUserID");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetwork_RelationFromUserID",
                table: "GQLUsersNetworks",
                newName: "IX_GQLUsersNetworks_RelationFromUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GQLUsersNetworks",
                table: "GQLUsersNetworks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GQLUsersNetworks_Users_RelationFromUserID",
                table: "GQLUsersNetworks",
                column: "RelationFromUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GQLUsersNetworks_Users_RelationToUserID",
                table: "GQLUsersNetworks",
                column: "RelationToUserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetworks_Users_RelationFromUserID",
                table: "GQLUsersNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_GQLUsersNetworks_Users_RelationToUserID",
                table: "GQLUsersNetworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GQLUsersNetworks",
                table: "GQLUsersNetworks");

            migrationBuilder.RenameTable(
                name: "GQLUsersNetworks",
                newName: "GQLUsersNetwork");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetworks_RelationToUserID",
                table: "GQLUsersNetwork",
                newName: "IX_GQLUsersNetwork_RelationToUserID");

            migrationBuilder.RenameIndex(
                name: "IX_GQLUsersNetworks_RelationFromUserID",
                table: "GQLUsersNetwork",
                newName: "IX_GQLUsersNetwork_RelationFromUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GQLUsersNetwork",
                table: "GQLUsersNetwork",
                column: "Id");

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
        }
    }
}
