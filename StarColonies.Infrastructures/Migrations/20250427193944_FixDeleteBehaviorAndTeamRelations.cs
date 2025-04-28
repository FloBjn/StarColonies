using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixDeleteBehaviorAndTeamRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScBonusObject_ScTeam_StarColoniesTeamTeamId",
                table: "ScBonusObject");

            migrationBuilder.DropForeignKey(
                name: "FK_ScMissionEnemies_ScEnemy_EnemyId",
                table: "ScMissionEnemies");

            migrationBuilder.DropTable(
                name: "StarColoniesColonStarColoniesTeam");

            migrationBuilder.DropIndex(
                name: "IX_ScBonusObject_StarColoniesTeamTeamId",
                table: "ScBonusObject");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "8001d346-0758-4b9c-92ac-4b60e7bf109e");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "8c880c71-faa7-438b-bfc7-b50b6cf9c9e0");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "c26c1ff1-b88f-49be-9aa6-fafa06edadbd");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "14683277-38cd-4f8b-8dbf-7d1f2a54da49");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "4cb23001-c8f4-4779-8e71-2d76aeae6660");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "9d8661b7-8b71-4afe-8f6c-22ab12995927");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "de449e12-4ea3-475b-8740-19ccf9bee767");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "1eebcbcf-c1d6-4378-952a-7b0b1c042df5");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "28b37e7c-af7e-472d-88e4-009122783b4d");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "448b5cc6-ec39-4b46-8dba-f8b3881743e6");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "8665c001-5c65-4759-b6b5-f79a3750dfe7");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "a17ce60f-ff7d-4354-9d74-59f79858802d");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "add6a440-90db-4a6e-b5bb-0fd910af2da4");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "c0b684fa-c049-4a85-936d-14bf355cd3ca");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "c3522360-e50b-47d8-81e7-d0151457fde8");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "c41a0f09-d71b-4c66-80a8-8b09301f0042");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "dc7a4232-1bfd-4aa7-bb7b-9b6d56bd210d");

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "1f4b61d2-8079-4bf2-881e-203dda31144c", "108ff542-3d17-4407-9028-34713b295c83" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "32b73efa-3550-458c-8e9c-ad7725417941", "108ff542-3d17-4407-9028-34713b295c83" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "32b73efa-3550-458c-8e9c-ad7725417941", "2cfd996d-1d34-4ad1-90ce-68268d09577e" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "46160fcc-941b-4d52-bd23-bfce1160e86b", "2cfd996d-1d34-4ad1-90ce-68268d09577e" });

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "1f4b61d2-8079-4bf2-881e-203dda31144c");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "32b73efa-3550-458c-8e9c-ad7725417941");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "46160fcc-941b-4d52-bd23-bfce1160e86b");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "108ff542-3d17-4407-9028-34713b295c83");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "2cfd996d-1d34-4ad1-90ce-68268d09577e");

            migrationBuilder.DropColumn(
                name: "StarColoniesTeamTeamId",
                table: "ScBonusObject");

            migrationBuilder.CreateTable(
                name: "ScTeamBonusObjects",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BonusObjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScTeamBonusObjects", x => new { x.TeamId, x.BonusObjectId });
                    table.ForeignKey(
                        name: "FK_ScTeamBonusObjects_ScBonusObject_BonusObjectId",
                        column: x => x.BonusObjectId,
                        principalTable: "ScBonusObject",
                        principalColumn: "BonusObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScTeamBonusObjects_ScTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "ScTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScTeamColonMembers",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScTeamColonMembers", x => new { x.TeamId, x.ColonId });
                    table.ForeignKey(
                        name: "FK_ScTeamColonMembers_ScColon_ColonId",
                        column: x => x.ColonId,
                        principalTable: "ScColon",
                        principalColumn: "ColonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScTeamColonMembers_ScTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "ScTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScBonusObject",
                columns: new[] { "BonusObjectId", "BonusForce", "BonusLevel", "BonusStamina", "Name", "Price" },
                values: new object[,]
                {
                    { "053ed450-edf9-48da-86aa-a7dadb4c6f9f", 0, 1, 0, "Potion Mystérieuse", 30 },
                    { "bfb416f4-8082-477b-97ec-6f9901072447", 1, 0, 0, "Barre protéinée", 5 },
                    { "d92391f7-4e52-4c66-a054-2116b64b985e", 0, 0, 1, "Boisson énergétique", 5 }
                });

            migrationBuilder.InsertData(
                table: "ScColon",
                columns: new[] { "ColonId", "Force", "JobName", "Level", "Name", "NumberResource", "Stamina" },
                values: new object[,]
                {
                    { "c6c08b63-79a1-4823-adc5-6a6340a0e7f2", 4, 2, 1, "Jason Blades", 0, 3 },
                    { "de660a14-5f29-4927-8a5a-6d7c88a03aba", 2, 3, 1, "Elara Starfinder", 0, 5 },
                    { "df927d1e-8488-47f2-a896-cf10b13b7b9f", 5, 1, 1, "Alex Striker", 0, 2 },
                    { "fdba8d36-5ca2-4598-ae38-ef0cbe83f2e4", 3, 0, 1, "Mira Nova", 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "ScEnemy",
                columns: new[] { "EnemyId", "EnemyTypeNameId", "Force", "Name", "Stamina" },
                values: new object[,]
                {
                    { "1c0fae70-f20f-4e30-b484-c992e6c238a4", 0, 1, "Nanobot", 2 },
                    { "1f679b72-1fd3-4e15-9b19-bc7a05284777", 5, 4, "Chimère", 4 },
                    { "28566c0e-2051-4be5-90cf-0912c87b0b00", 2, 20, "Hégémon", 20 },
                    { "2972c34f-4306-4a92-980e-8c8cb78fa765", 0, 2, "Drone", 2 },
                    { "32b543a6-fd50-4295-b555-a155ee5bc254", 3, 7, "Spectre", 1 },
                    { "55658482-faf4-4ac7-88c9-b38914f3e459", 2, 5, "Titan", 3 },
                    { "5d11e4cf-ef07-428e-9e47-4ffc9cd74751", 0, 20, "Drone de combat", 15 },
                    { "7738d91a-f76b-4d37-8e00-342f18f2f29f", 2, 9, "Leviathan", 7 },
                    { "ac33c19b-79d0-4874-a36e-ea0dc3fc09e8", 3, 5, "Entité", 11 },
                    { "cdab3373-1abc-45e8-ae98-408e85173513", 2, 4, "Cryptoïde", 12 },
                    { "d893545b-3f05-42ce-9d0b-1fcd989507f4", 1, 1, "Anomalie", 3 },
                    { "da85392e-e5cd-48ec-a2d8-e063c169bd28", 4, 4, "Prédateur", 3 },
                    { "fcc3abd0-bb9a-4bad-836a-2f8c43d237ee", 6, 2, "Mutant", 4 }
                });

            migrationBuilder.InsertData(
                table: "ScMission",
                columns: new[] { "MissionId", "Name" },
                values: new object[,]
                {
                    { "0a2c106b-1d7f-4d9e-8885-9068531b2302", "Test" },
                    { "5daec1cd-fdaa-4568-a774-b1c202a5ea6a", "Exploration de la base abandonnée" }
                });

            migrationBuilder.InsertData(
                table: "ScMissionEnemies",
                columns: new[] { "EnemyId", "MissionId" },
                values: new object[,]
                {
                    { "55658482-faf4-4ac7-88c9-b38914f3e459", "0a2c106b-1d7f-4d9e-8885-9068531b2302" },
                    { "da85392e-e5cd-48ec-a2d8-e063c169bd28", "0a2c106b-1d7f-4d9e-8885-9068531b2302" },
                    { "d893545b-3f05-42ce-9d0b-1fcd989507f4", "5daec1cd-fdaa-4568-a774-b1c202a5ea6a" },
                    { "da85392e-e5cd-48ec-a2d8-e063c169bd28", "5daec1cd-fdaa-4568-a774-b1c202a5ea6a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScTeamBonusObjects_BonusObjectId",
                table: "ScTeamBonusObjects",
                column: "BonusObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScTeamColonMembers_ColonId",
                table: "ScTeamColonMembers",
                column: "ColonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScMissionEnemies_ScEnemy_EnemyId",
                table: "ScMissionEnemies",
                column: "EnemyId",
                principalTable: "ScEnemy",
                principalColumn: "EnemyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScMissionEnemies_ScEnemy_EnemyId",
                table: "ScMissionEnemies");

            migrationBuilder.DropTable(
                name: "ScTeamBonusObjects");

            migrationBuilder.DropTable(
                name: "ScTeamColonMembers");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "053ed450-edf9-48da-86aa-a7dadb4c6f9f");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "bfb416f4-8082-477b-97ec-6f9901072447");

            migrationBuilder.DeleteData(
                table: "ScBonusObject",
                keyColumn: "BonusObjectId",
                keyValue: "d92391f7-4e52-4c66-a054-2116b64b985e");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "c6c08b63-79a1-4823-adc5-6a6340a0e7f2");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "de660a14-5f29-4927-8a5a-6d7c88a03aba");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "df927d1e-8488-47f2-a896-cf10b13b7b9f");

            migrationBuilder.DeleteData(
                table: "ScColon",
                keyColumn: "ColonId",
                keyValue: "fdba8d36-5ca2-4598-ae38-ef0cbe83f2e4");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "1c0fae70-f20f-4e30-b484-c992e6c238a4");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "1f679b72-1fd3-4e15-9b19-bc7a05284777");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "28566c0e-2051-4be5-90cf-0912c87b0b00");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "2972c34f-4306-4a92-980e-8c8cb78fa765");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "32b543a6-fd50-4295-b555-a155ee5bc254");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "5d11e4cf-ef07-428e-9e47-4ffc9cd74751");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "7738d91a-f76b-4d37-8e00-342f18f2f29f");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "ac33c19b-79d0-4874-a36e-ea0dc3fc09e8");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "cdab3373-1abc-45e8-ae98-408e85173513");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "fcc3abd0-bb9a-4bad-836a-2f8c43d237ee");

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "55658482-faf4-4ac7-88c9-b38914f3e459", "0a2c106b-1d7f-4d9e-8885-9068531b2302" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "da85392e-e5cd-48ec-a2d8-e063c169bd28", "0a2c106b-1d7f-4d9e-8885-9068531b2302" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "d893545b-3f05-42ce-9d0b-1fcd989507f4", "5daec1cd-fdaa-4568-a774-b1c202a5ea6a" });

            migrationBuilder.DeleteData(
                table: "ScMissionEnemies",
                keyColumns: new[] { "EnemyId", "MissionId" },
                keyValues: new object[] { "da85392e-e5cd-48ec-a2d8-e063c169bd28", "5daec1cd-fdaa-4568-a774-b1c202a5ea6a" });

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "55658482-faf4-4ac7-88c9-b38914f3e459");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "d893545b-3f05-42ce-9d0b-1fcd989507f4");

            migrationBuilder.DeleteData(
                table: "ScEnemy",
                keyColumn: "EnemyId",
                keyValue: "da85392e-e5cd-48ec-a2d8-e063c169bd28");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "0a2c106b-1d7f-4d9e-8885-9068531b2302");

            migrationBuilder.DeleteData(
                table: "ScMission",
                keyColumn: "MissionId",
                keyValue: "5daec1cd-fdaa-4568-a774-b1c202a5ea6a");

            migrationBuilder.AddColumn<string>(
                name: "StarColoniesTeamTeamId",
                table: "ScBonusObject",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StarColoniesColonStarColoniesTeam",
                columns: table => new
                {
                    ColonsTeamColonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamsTeamId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarColoniesColonStarColoniesTeam", x => new { x.ColonsTeamColonId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_StarColoniesColonStarColoniesTeam_ScColon_ColonsTeamColonId",
                        column: x => x.ColonsTeamColonId,
                        principalTable: "ScColon",
                        principalColumn: "ColonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarColoniesColonStarColoniesTeam_ScTeam_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "ScTeam",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScBonusObject",
                columns: new[] { "BonusObjectId", "BonusForce", "BonusLevel", "BonusStamina", "Name", "Price", "StarColoniesTeamTeamId" },
                values: new object[,]
                {
                    { "8001d346-0758-4b9c-92ac-4b60e7bf109e", 0, 0, 1, "Boisson énergétique", 5, null },
                    { "8c880c71-faa7-438b-bfc7-b50b6cf9c9e0", 1, 0, 0, "Barre protéinée", 5, null },
                    { "c26c1ff1-b88f-49be-9aa6-fafa06edadbd", 0, 1, 0, "Potion Mystérieuse", 30, null }
                });

            migrationBuilder.InsertData(
                table: "ScColon",
                columns: new[] { "ColonId", "Force", "JobName", "Level", "Name", "NumberResource", "Stamina" },
                values: new object[,]
                {
                    { "14683277-38cd-4f8b-8dbf-7d1f2a54da49", 2, 3, 1, "Elara Starfinder", 0, 5 },
                    { "4cb23001-c8f4-4779-8e71-2d76aeae6660", 3, 0, 1, "Mira Nova", 0, 4 },
                    { "9d8661b7-8b71-4afe-8f6c-22ab12995927", 4, 2, 1, "Jason Blades", 0, 3 },
                    { "de449e12-4ea3-475b-8740-19ccf9bee767", 5, 1, 1, "Alex Striker", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ScEnemy",
                columns: new[] { "EnemyId", "EnemyTypeNameId", "Force", "Name", "Stamina" },
                values: new object[,]
                {
                    { "1eebcbcf-c1d6-4378-952a-7b0b1c042df5", 5, 4, "Chimère", 4 },
                    { "1f4b61d2-8079-4bf2-881e-203dda31144c", 1, 1, "Anomalie", 3 },
                    { "28b37e7c-af7e-472d-88e4-009122783b4d", 0, 1, "Nanobot", 2 },
                    { "32b73efa-3550-458c-8e9c-ad7725417941", 4, 4, "Prédateur", 3 },
                    { "448b5cc6-ec39-4b46-8dba-f8b3881743e6", 0, 2, "Drone", 2 },
                    { "46160fcc-941b-4d52-bd23-bfce1160e86b", 2, 5, "Titan", 3 },
                    { "8665c001-5c65-4759-b6b5-f79a3750dfe7", 2, 9, "Leviathan", 7 },
                    { "a17ce60f-ff7d-4354-9d74-59f79858802d", 2, 4, "Cryptoïde", 12 },
                    { "add6a440-90db-4a6e-b5bb-0fd910af2da4", 3, 5, "Entité", 11 },
                    { "c0b684fa-c049-4a85-936d-14bf355cd3ca", 2, 20, "Hégémon", 20 },
                    { "c3522360-e50b-47d8-81e7-d0151457fde8", 6, 2, "Mutant", 4 },
                    { "c41a0f09-d71b-4c66-80a8-8b09301f0042", 0, 20, "Drone de combat", 15 },
                    { "dc7a4232-1bfd-4aa7-bb7b-9b6d56bd210d", 3, 7, "Spectre", 1 }
                });

            migrationBuilder.InsertData(
                table: "ScMission",
                columns: new[] { "MissionId", "Name" },
                values: new object[,]
                {
                    { "108ff542-3d17-4407-9028-34713b295c83", "Exploration de la base abandonnée" },
                    { "2cfd996d-1d34-4ad1-90ce-68268d09577e", "Test" }
                });

            migrationBuilder.InsertData(
                table: "ScMissionEnemies",
                columns: new[] { "EnemyId", "MissionId" },
                values: new object[,]
                {
                    { "1f4b61d2-8079-4bf2-881e-203dda31144c", "108ff542-3d17-4407-9028-34713b295c83" },
                    { "32b73efa-3550-458c-8e9c-ad7725417941", "108ff542-3d17-4407-9028-34713b295c83" },
                    { "32b73efa-3550-458c-8e9c-ad7725417941", "2cfd996d-1d34-4ad1-90ce-68268d09577e" },
                    { "46160fcc-941b-4d52-bd23-bfce1160e86b", "2cfd996d-1d34-4ad1-90ce-68268d09577e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScBonusObject_StarColoniesTeamTeamId",
                table: "ScBonusObject",
                column: "StarColoniesTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_StarColoniesColonStarColoniesTeam_TeamsTeamId",
                table: "StarColoniesColonStarColoniesTeam",
                column: "TeamsTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScBonusObject_ScTeam_StarColoniesTeamTeamId",
                table: "ScBonusObject",
                column: "StarColoniesTeamTeamId",
                principalTable: "ScTeam",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScMissionEnemies_ScEnemy_EnemyId",
                table: "ScMissionEnemies",
                column: "EnemyId",
                principalTable: "ScEnemy",
                principalColumn: "EnemyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
