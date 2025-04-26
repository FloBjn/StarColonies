using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ScJob",
                columns: new[] { "JobId", "Name" },
                values: new object[,]
                {
                    { "0a67a5a3-7c76-4fdc-8917-74fa7deccc83", 2 },
                    { "0cb30165-7d1a-49f7-adc3-2a77e95c3558", 3 },
                    { "6335c75c-25fa-4d42-b7ef-19a7a25b50ca", 0 },
                    { "9cab68ff-ec7e-422e-bd7a-271704628abb", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "0a67a5a3-7c76-4fdc-8917-74fa7deccc83");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "0cb30165-7d1a-49f7-adc3-2a77e95c3558");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "6335c75c-25fa-4d42-b7ef-19a7a25b50ca");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "9cab68ff-ec7e-422e-bd7a-271704628abb");
        }
    }
}
