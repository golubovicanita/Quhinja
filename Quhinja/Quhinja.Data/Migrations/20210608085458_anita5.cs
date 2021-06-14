using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quhinja.Data.Migrations
{
    public partial class anita5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a1ca4ec0-ef90-43af-84c3-695de80280b9");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fd9e1839-7e4f-4102-adf9-1fb6ef11cc61");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "DateOfEmployment" },
                values: new object[] { "370fe51a-a803-4c7c-b44c-3eb1ba061075", new DateTime(2021, 6, 8, 10, 54, 56, 356, DateTimeKind.Local).AddTicks(1380), new DateTime(2021, 6, 8, 10, 54, 56, 368, DateTimeKind.Local).AddTicks(7107) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
