using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModidyJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScColon_ScJob_JobId",
                table: "ScColon");

            migrationBuilder.DropTable(
                name: "ScJob");

            migrationBuilder.DropIndex(
                name: "IX_ScColon_JobId",
                table: "ScColon");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ScColon");

            migrationBuilder.AddColumn<int>(
                name: "JobName",
                table: "ScColon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "ScColon");

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "ScColon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ScJob",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScJob", x => x.JobId);
                });

            migrationBuilder.InsertData(
                table: "ScJob",
                columns: new[] { "JobId", "Name" },
                values: new object[,]
                {
                    { "13e11e4f-02de-4e1d-a41d-69104ffd71ef", 0 },
                    { "62c68f7b-c8d6-44c3-b612-3ef747d1dda8", 3 },
                    { "6c14c5e9-d410-4a6e-a1b4-f37d33f54fa0", 1 },
                    { "8feedfd5-e9bd-4ab3-8c4f-1e39b8211585", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScColon_JobId",
                table: "ScColon",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScColon_ScJob_JobId",
                table: "ScColon",
                column: "JobId",
                principalTable: "ScJob",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
