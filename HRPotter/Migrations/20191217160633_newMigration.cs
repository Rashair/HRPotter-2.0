using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(7936), new DateTime(2019, 12, 27, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9538), new DateTime(2019, 12, 22, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 17, 17, 6, 33, 310, DateTimeKind.Local).AddTicks(9695));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
