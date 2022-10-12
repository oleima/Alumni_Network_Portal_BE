using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni_Network_Portal_BE.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 12, 51, 51, 809, DateTimeKind.Local).AddTicks(3084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 12, 10, 33, 20, 849, DateTimeKind.Local).AddTicks(2105));
        }
    }
}
