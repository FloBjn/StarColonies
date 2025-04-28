using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScEnemy_ScMission_StarColoniesMissionMissionId",
                table: "ScEnemy");

            migrationBuilder.DropIndex(
                name: "IX_ScEnemy_StarColoniesMissionMissionId",
                table: "ScEnemy");

            migrationBuilder.DropColumn(
                name: "EnemyTypeId",
                table: "ScEnemy");

            migrationBuilder.DropColumn(
                name: "StarColoniesMissionMissionId",
                table: "ScEnemy");

            migrationBuilder.RenameColumn(
                name: "EnemyType",
                table: "ScEnemy",
                newName: "Stamina");

            migrationBuilder.AddColumn<int>(
                name: "EnemyTypeNameId",
                table: "ScEnemy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Force",
                table: "ScEnemy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScMissionEnemies",
                columns: table => new
                {
                    MissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnemyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScMissionEnemies", x => new { x.MissionId, x.EnemyId });
                    table.ForeignKey(
                        name: "FK_ScMissionEnemies_ScEnemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "ScEnemy",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScMissionEnemies_ScMission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "ScMission",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScBonusObject",
                columns: new[] { "BonusObjectId", "BonusForce", "BonusLevel", "BonusStamina", "Name", "Price", "StarColoniesTeamTeamId" },
                values: new object[,]
                {
                    { "10a71b88-3771-44f7-92d4-08d3c5ea93b5", 0, 0, 1, "Boisson énergétique", 5, null },
                    { "215da2e7-0eb4-4f8e-a529-2928c090b354", 0, 1, 0, "Potion Mystérieuse", 30, null },
                    { "3667653f-9fd9-4748-8101-9c13bc117695", 1, 0, 0, "Barre protéinée", 5, null }
                });

            migrationBuilder.InsertData(
                table: "ScColon",
                columns: new[] { "ColonId", "Force", "JobName", "Level", "Name", "NumberResource", "Stamina" },
                values: new object[,]
                {
                    { "36e14fab-bb72-460d-b4b0-4842f97d6fef", 4, 2, 1, "Jason Blades", 0, 3 },
                    { "835068fe-54ad-404f-9711-2c450f18d417", 2, 3, 1, "Elara Starfinder", 0, 5 },
                    { "b6252502-0fb1-4d6e-bf6a-f196929e6afa", 3, 0, 1, "Mira Nova", 0, 4 },
                    { "dfa77258-203f-4a23-bf80-5f28e58d1ed9", 5, 1, 1, "Alex Striker", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ScEnemy",
                columns: new[] { "EnemyId", "EnemyTypeNameId", "Force", "Name", "Stamina" },
                values: new object[,]
                {
                    { "02334bc7-fd9d-4b1f-90a4-0a0cf53f52a5", 3, 7, "Spectre", 1 },
                    { "296aea32-788a-4def-bec0-ce472200429e", 4, 4, "Prédateur", 3 },
                    { "42a7b42b-6909-4b23-abd2-13b45af997f8", 5, 4, "Chimère", 4 },
                    { "642493e3-dd2f-4e8d-bd27-4d513282c8ee", 2, 20, "Hégémon", 20 },
                    { "76e06b9d-f52e-497f-a938-c35fa4c70555", 0, 20, "Drone de combat", 15 },
                    { "883659c9-8f2d-4cf0-94b1-c7e687a08023", 6, 2, "Mutant", 4 },
                    { "8c7c2669-954d-46f8-91e1-8e1864ff9a63", 1, 1, "Anomalie", 3 },
                    { "b951574b-c884-419d-b011-a3f86e846968", 3, 5, "Entité", 11 },
                    { "b97948b7-b3e1-4d4a-a30f-c5a90563fa89", 2, 4, "Cryptoïde", 12 },
                    { "bb138735-e4b4-47fc-8731-e8fad7bf6cb9", 0, 2, "Drone", 2 },
                    { "c148b0bd-2577-4b59-ab22-7f018a2ccf65", 2, 9, "Leviathan", 7 },
                    { "f2574d42-118d-483c-b029-fd9a90741936", 0, 1, "Nanobot", 2 },
                    { "f9a6df25-3a59-4234-9bf1-2882feb66f42", 2, 5, "Titan", 3 }
                });

            migrationBuilder.InsertData(
                table: "ScMission",
                columns: new[] { "MissionId", "Name" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", "Exploration de la base abandonnée" });

            migrationBuilder.InsertData(
                table: "ScMissionEnemies",
                columns: new[] { "EnemyId", "MissionId" },
                values: new object[,]
                {
                    { "296aea32-788a-4def-bec0-ce472200429e", "00000000-0000-0000-0000-000000000000" },
                    { "8c7c2669-954d-46f8-91e1-8e1864ff9a63", "00000000-0000-0000-0000-000000000000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScMissionEnemies_EnemyId",
                table: "ScMissionEnemies",
                column: "EnemyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScMissionEnemies");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "10a71b88-3771-44f7-92d4-08d3c5ea93b5");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "215da2e7-0eb4-4f8e-a529-2928c090b354");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "3667653f-9fd9-4748-8101-9c13bc117695");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "36e14fab-bb72-460d-b4b0-4842f97d6fef");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "835068fe-54ad-404f-9711-2c450f18d417");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "b6252502-0fb1-4d6e-bf6a-f196929e6afa");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "dfa77258-203f-4a23-bf80-5f28e58d1ed9");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "02334bc7-fd9d-4b1f-90a4-0a0cf53f52a5");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "296aea32-788a-4def-bec0-ce472200429e");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "42a7b42b-6909-4b23-abd2-13b45af997f8");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "642493e3-dd2f-4e8d-bd27-4d513282c8ee");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "76e06b9d-f52e-497f-a938-c35fa4c70555");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "883659c9-8f2d-4cf0-94b1-c7e687a08023");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "8c7c2669-954d-46f8-91e1-8e1864ff9a63");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "b951574b-c884-419d-b011-a3f86e846968");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "b97948b7-b3e1-4d4a-a30f-c5a90563fa89");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "bb138735-e4b4-47fc-8731-e8fad7bf6cb9");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "c148b0bd-2577-4b59-ab22-7f018a2ccf65");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "f2574d42-118d-483c-b029-fd9a90741936");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "f9a6df25-3a59-4234-9bf1-2882feb66f42");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.DropColumn(
                name: "EnemyTypeNameId",
                table: "ScEnemy");

            migrationBuilder.DropColumn(
                name: "Force",
                table: "ScEnemy");

            migrationBuilder.RenameColumn(
                name: "Stamina",
                table: "ScEnemy",
                newName: "EnemyType");

            migrationBuilder.AddColumn<string>(
                name: "EnemyTypeId",
                table: "ScEnemy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StarColoniesMissionMissionId",
                table: "ScEnemy",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScEnemy_StarColoniesMissionMissionId",
                table: "ScEnemy",
                column: "StarColoniesMissionMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScEnemy_ScMission_StarColoniesMissionMissionId",
                table: "ScEnemy",
                column: "StarColoniesMissionMissionId",
                principalTable: "ScMission",
                principalColumn: "MissionId");
        }
    }
}
