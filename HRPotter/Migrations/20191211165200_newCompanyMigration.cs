using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class newCompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Wizarding World" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(3200), new DateTime(2019, 12, 21, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4320), new DateTime(2019, 12, 16, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 11, 17, 52, 0, 58, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "HR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 654, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(8145), new DateTime(2019, 12, 17, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9349), new DateTime(2019, 12, 12, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "HRUser");
        }
    }
}
