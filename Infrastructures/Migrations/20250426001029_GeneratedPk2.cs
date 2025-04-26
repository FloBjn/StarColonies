using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarColonies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class GeneratedPk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "13e11e4f-02de-4e1d-a41d-69104ffd71ef", 0 },
                    { "62c68f7b-c8d6-44c3-b612-3ef747d1dda8", 3 },
                    { "6c14c5e9-d410-4a6e-a1b4-f37d33f54fa0", 1 },
                    { "8feedfd5-e9bd-4ab3-8c4f-1e39b8211585", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "13e11e4f-02de-4e1d-a41d-69104ffd71ef");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "62c68f7b-c8d6-44c3-b612-3ef747d1dda8");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "6c14c5e9-d410-4a6e-a1b4-f37d33f54fa0");

            migrationBuilder.DeleteData(
                table: "ScJob",
                keyColumn: "JobId",
                keyValue: "8feedfd5-e9bd-4ab3-8c4f-1e39b8211585");

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
    }
}
