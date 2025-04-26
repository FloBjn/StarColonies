using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class GeneratedPk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ScJob",
                columns: new[] { "JobId", "Name" },
                values: new object[,]
                {
                    { "14bf2079-50e7-4bde-91c2-4af2b072dc91", 1 },
                    { "1aab459f-3056-4d0c-894a-be19bbdf1253", 0 },
                    { "3bec4f47-fdaf-400e-a5f7-396e5ef9d2f2", 2 },
                    { "8bb96362-c75b-463a-a091-89f9ffbd2c50", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "14bf2079-50e7-4bde-91c2-4af2b072dc91");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "1aab459f-3056-4d0c-894a-be19bbdf1253");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "3bec4f47-fdaf-400e-a5f7-396e5ef9d2f2");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "8bb96362-c75b-463a-a091-89f9ffbd2c50");

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
    }
}
