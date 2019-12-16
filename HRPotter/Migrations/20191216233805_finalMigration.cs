using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(3918), new DateTime(2019, 12, 27, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(3957) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5309), new DateTime(2019, 12, 22, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 17, 0, 38, 5, 126, DateTimeKind.Local).AddTicks(5500));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
