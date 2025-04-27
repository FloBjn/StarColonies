using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "296aea32-788a-4def-bec0-ce472200429e", "00000000-0000-0000-0000-000000000000" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "8c7c2669-954d-46f8-91e1-8e1864ff9a63", "00000000-0000-0000-0000-000000000000" });

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "296aea32-788a-4def-bec0-ce472200429e");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "8c7c2669-954d-46f8-91e1-8e1864ff9a63");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.InsertData(
                table: "ScBonusObject",
                columns: new[] { "BonusObjectId", "BonusForce", "BonusLevel", "BonusStamina", "Name", "Price", "StarColoniesTeamTeamId" },
                values: new object[,]
                {
                    { "3779c08e-6145-4109-96fd-4aff7179a5cc", 0, 1, 0, "Potion Mystérieuse", 30, null },
                    { "3c94032b-fa6c-4743-8d11-480bae2f0c45", 0, 0, 1, "Boisson énergétique", 5, null },
                    { "733861f1-83ad-4336-9125-73263d5c5da1", 1, 0, 0, "Barre protéinée", 5, null }
                });

            migrationBuilder.InsertData(
                table: "ScColon",
                columns: new[] { "ColonId", "Force", "JobName", "Level", "Name", "NumberResource", "Stamina" },
                values: new object[,]
                {
                    { "1d5195e9-c0c1-4794-9513-bcfd16800250", 4, 2, 1, "Jason Blades", 0, 3 },
                    { "4b40cddf-b714-48aa-ac0d-442b1c0f4f88", 5, 1, 1, "Alex Striker", 0, 2 },
                    { "821a9092-90c7-42b9-b1a2-aa556a0f89c5", 3, 0, 1, "Mira Nova", 0, 4 },
                    { "c01445b1-bd43-4b4b-bd85-a0c3b8b63af3", 2, 3, 1, "Elara Starfinder", 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "ScEnemy",
                columns: new[] { "EnemyId", "EnemyTypeNameId", "Force", "Name", "Stamina" },
                values: new object[,]
                {
                    { "19a1300e-06f9-4c20-8262-32c4d3f33f22", 0, 20, "Drone de combat", 15 },
                    { "237e2cc8-67d7-44bb-a26a-0c2c94a8057b", 2, 20, "Hégémon", 20 },
                    { "3714e019-45aa-436c-94b2-2667b22ced5b", 6, 2, "Mutant", 4 },
                    { "69a21f70-759d-4edd-b0f9-2fc0673f9192", 4, 4, "Prédateur", 3 },
                    { "6f043d86-dfc7-4f03-adac-d246d9455131", 2, 5, "Titan", 3 },
                    { "79c856f1-f970-4027-8be9-c2b2a33067ba", 2, 4, "Cryptoïde", 12 },
                    { "9e7b0b1a-d06a-4259-958a-78aae827b98d", 2, 9, "Leviathan", 7 },
                    { "b9215b7b-6bd1-45d9-8f90-e2050fc2de2b", 0, 1, "Nanobot", 2 },
                    { "c974685a-4dc4-41b7-93a8-98d6b104715c", 5, 4, "Chimère", 4 },
                    { "cdb8ad6a-1e13-49f2-b6d9-8bddeb41a71c", 3, 5, "Entité", 11 },
                    { "e1f69ce6-800a-4cc2-98b4-05ca6f5a062a", 1, 1, "Anomalie", 3 },
                    { "ee14a6df-ba7c-4a2f-8a35-50661d0f718a", 3, 7, "Spectre", 1 },
                    { "f64e8288-051f-449d-a7e6-1e326690646c", 0, 2, "Drone", 2 }
                });

            migrationBuilder.InsertData(
                table: "ScMission",
                columns: new[] { "MissionId", "Name" },
                values: new object[] { "5e8afb9a-063d-47a6-a897-9bcb6a319f45", "Exploration de la base abandonnée" });

            migrationBuilder.InsertData(
                table: "ScMissionEnemies",
                columns: new[] { "EnemyId", "MissionId" },
                values: new object[,]
                {
                    { "69a21f70-759d-4edd-b0f9-2fc0673f9192", "5e8afb9a-063d-47a6-a897-9bcb6a319f45" },
                    { "e1f69ce6-800a-4cc2-98b4-05ca6f5a062a", "5e8afb9a-063d-47a6-a897-9bcb6a319f45" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "3779c08e-6145-4109-96fd-4aff7179a5cc");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "3c94032b-fa6c-4743-8d11-480bae2f0c45");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "733861f1-83ad-4336-9125-73263d5c5da1");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "1d5195e9-c0c1-4794-9513-bcfd16800250");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "4b40cddf-b714-48aa-ac0d-442b1c0f4f88");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "821a9092-90c7-42b9-b1a2-aa556a0f89c5");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "c01445b1-bd43-4b4b-bd85-a0c3b8b63af3");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "19a1300e-06f9-4c20-8262-32c4d3f33f22");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "237e2cc8-67d7-44bb-a26a-0c2c94a8057b");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "3714e019-45aa-436c-94b2-2667b22ced5b");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "6f043d86-dfc7-4f03-adac-d246d9455131");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "79c856f1-f970-4027-8be9-c2b2a33067ba");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "9e7b0b1a-d06a-4259-958a-78aae827b98d");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "b9215b7b-6bd1-45d9-8f90-e2050fc2de2b");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "c974685a-4dc4-41b7-93a8-98d6b104715c");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "cdb8ad6a-1e13-49f2-b6d9-8bddeb41a71c");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "ee14a6df-ba7c-4a2f-8a35-50661d0f718a");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "f64e8288-051f-449d-a7e6-1e326690646c");

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "69a21f70-759d-4edd-b0f9-2fc0673f9192", "5e8afb9a-063d-47a6-a897-9bcb6a319f45" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "e1f69ce6-800a-4cc2-98b4-05ca6f5a062a", "5e8afb9a-063d-47a6-a897-9bcb6a319f45" });

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "69a21f70-759d-4edd-b0f9-2fc0673f9192");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "e1f69ce6-800a-4cc2-98b4-05ca6f5a062a");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "5e8afb9a-063d-47a6-a897-9bcb6a319f45");

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
        }
    }
}
