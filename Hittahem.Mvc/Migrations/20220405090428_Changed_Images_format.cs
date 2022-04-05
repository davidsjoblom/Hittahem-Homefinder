using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hittahem.Mvc.Migrations
{
    public partial class Changed_Images_format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomeViewings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 5, 11, 4, 27, 627, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2022, 4, 5, 9, 4, 27, 627, DateTimeKind.Utc).AddTicks(9285));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HomeViewings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 1, 9, 19, 41, 477, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2022, 4, 1, 7, 19, 41, 477, DateTimeKind.Utc).AddTicks(2406));
        }
    }
}
