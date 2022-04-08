using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hittahem.Mvc.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomeViewings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 8, 12, 7, 4, 395, DateTimeKind.Local).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2022, 4, 8, 10, 7, 4, 395, DateTimeKind.Utc).AddTicks(3284));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomeViewings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 8, 11, 26, 16, 346, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2022, 4, 8, 9, 26, 16, 346, DateTimeKind.Utc).AddTicks(564));
        }
    }
}
