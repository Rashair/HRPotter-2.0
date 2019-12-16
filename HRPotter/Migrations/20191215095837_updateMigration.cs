using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CvUrl",
                value: "TAiJF_Cwiczenie_04.pdf");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 462, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(1803), new DateTime(2019, 12, 25, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2725), new DateTime(2019, 12, 20, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2738) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 15, 10, 58, 37, 465, DateTimeKind.Local).AddTicks(2802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CvUrl",
                value: "https://www.google.com/");

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
        }
    }
}
