using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hittahem.Mvc.Migrations
{
    public partial class Changed_Images_format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "HomeImages",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "HomeViewings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 5, 11, 19, 22, 48, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePosted",
                value: new DateTime(2022, 4, 5, 9, 19, 22, 48, DateTimeKind.Utc).AddTicks(7251));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "HomeImages",
                newName: "Image");

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
    }
}
