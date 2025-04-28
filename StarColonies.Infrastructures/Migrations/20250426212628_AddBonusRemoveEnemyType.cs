using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddBonusRemoveEnemyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ScColon_UserColonColonId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ScEnemyType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserColonColonId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserColonColonId",
                table: "AspNetUsers",
                newName: "ColonId");

            migrationBuilder.AddColumn<int>(
                name: "LevelMaxAuthorized",
                table: "ScTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnemyType",
                table: "ScEnemy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnemyTypeId",
                table: "ScEnemy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "ScColon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberResource",
                table: "ScColon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScBonusObject",
                columns: table => new
                {
                    BonusObjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BonusLevel = table.Column<int>(type: "int", nullable: false),
                    BonusForce = table.Column<int>(type: "int", nullable: false),
                    BonusStamina = table.Column<int>(type: "int", nullable: false),
                    StarColoniesTeamTeamId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScBonusObject", x => x.BonusObjectId);
                    table.ForeignKey(
                        name: "FK_ScBonusObject_ScTeam_StarColoniesTeamTeamId",
                        column: x => x.StarColoniesTeamTeamId,
                        principalTable: "ScTeam",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "ScMissionHistory",
                columns: table => new
                {
                    MissionHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMissionHistory", x => x.MissionHistoryId);
                    table.ForeignKey(
                        name: "FK_ScMissionHistory_ScMission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "ScMission",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScMissionHistory_ScTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "ScTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ColonId",
                table: "AspNetUsers",
                column: "ColonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScBonusObject_StarColoniesTeamTeamId",
                table: "ScBonusObject",
                column: "StarColoniesTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMissionHistory_MissionId",
                table: "ScMissionHistory",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScMissionHistory_TeamId",
                table: "ScMissionHistory",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ScColon_ColonId",
                table: "AspNetUsers",
                column: "ColonId",
                principalTable: "ScColon",
                principalColumn: "ColonId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ScColon_ColonId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ScBonusObject");

            migrationBuilder.DropTable(
                name: "ScMissionHistory");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ColonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LevelMaxAuthorized",
                table: "ScTeam");

            migrationBuilder.DropColumn(
                name: "EnemyType",
                table: "ScEnemy");

            migrationBuilder.DropColumn(
                name: "EnemyTypeId",
                table: "ScEnemy");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "ScColon");

            migrationBuilder.DropColumn(
                name: "NumberResource",
                table: "ScColon");

            migrationBuilder.RenameColumn(
                name: "ColonId",
                table: "AspNetUsers",
                newName: "UserColonColonId");

            migrationBuilder.CreateTable(
                name: "ScEnemyType",
                columns: table => new
                {
                    EnemyTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScEnemyType", x => x.EnemyTypeId);
                    table.ForeignKey(
                        name: "FK_ScEnemyType_ScEnemy_EnemyTypeId",
                        column: x => x.EnemyTypeId,
                        principalTable: "ScEnemy",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserColonColonId",
                table: "AspNetUsers",
                column: "UserColonColonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ScColon_UserColonColonId",
                table: "AspNetUsers",
                column: "UserColonColonId",
                principalTable: "ScColon",
                principalColumn: "ColonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
