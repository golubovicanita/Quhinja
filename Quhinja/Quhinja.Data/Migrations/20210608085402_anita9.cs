using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class anita9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "19587ee5-e152-448d-9160-abd53efae7d7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "633757dd-3437-4aa9-b72e-106927b52fba");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "0d0f1b8f-4cfc-46e6-b120-f8878623118d", new DateTime(2021, 6, 8, 10, 54, 0, 197, DateTimeKind.Local).AddTicks(7097), new DateTime(2021, 6, 8, 10, 54, 0, 209, DateTimeKind.Local).AddTicks(4401) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "633e2818-410a-4569-9b02-23c2e0537a41");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "860463f3-8cd2-483b-a780-878251b0a9a1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "1e3997d6-6901-4a5a-ae61-dc67ecae774e", new DateTime(2021, 6, 8, 10, 51, 12, 993, DateTimeKind.Local).AddTicks(5445), new DateTime(2021, 6, 8, 10, 51, 13, 6, DateTimeKind.Local).AddTicks(6387) });
        }
    }
}
