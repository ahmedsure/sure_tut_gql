using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GQLDEMOTUT.Migrations
{
    public partial class frindships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfileIMGPath",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfilePath",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersNetworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationFromUserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationToUserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FrindshipDescription = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersNetworks_Users_RelationFromUserID",
                        column: x => x.RelationFromUserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersNetworks_Users_RelationToUserID",
                        column: x => x.RelationToUserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsersNetworks",
                columns: new[] { "Id", "FrindshipDescription", "RelationFromUserID", "RelationToUserID" },
                values: new object[] { new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"), 0, new Guid("01b72b5b-955b-45a8-b6fe-efce8162a7db"), new Guid("01b55555-955b-45a8-b6fe-efce8162a755") });

            migrationBuilder.CreateIndex(
                name: "IX_UsersNetworks_RelationFromUserID",
                table: "UsersNetworks",
                column: "RelationFromUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersNetworks_RelationToUserID",
                table: "UsersNetworks",
                column: "RelationToUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersNetworks");

            migrationBuilder.DropColumn(
                name: "UserProfileIMGPath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProfilePath",
                table: "Users");
        }
    }
}
